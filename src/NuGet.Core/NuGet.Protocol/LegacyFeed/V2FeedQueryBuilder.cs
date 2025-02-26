// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Copyright (c) 2015-2022 .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using NuGet.Common;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;

//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
using Chocolatey.NuGet.Frameworks;
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////

namespace NuGet.Protocol
{
    /// <summary>
    /// Build the path part of a V2 feed URL. These values are appended to the V2 base URL.
    /// </summary>
    public class V2FeedQueryBuilder
    {
        // shared constants
        private const string IsLatestVersionFilterFlag = "IsLatestVersion";
        private const string IsAbsoluteLatestVersionFilterFlag = "IsAbsoluteLatestVersion";
        private const string IdProperty = "Id";
        private const string SemVerLevel = "semVerLevel=2.0.0";

        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

        private const string DownloadCountProperty = "DownloadCount";
        private const string VersionProperty = "Version";

        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

        // constants for /Packages(ID,VERSION) endpoint
        private const string GetSpecificPackageFormat = "/Packages(Id='{0}',Version='{1}')";

        // constants for /Search() endpoint

        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

        private const string SearchEndpointFormat = "/Search()?{0}{1}searchTerm='{2}'&targetFramework='{3}'&includePrerelease={4}&$skip={5}&$top={6}&" + SemVerLevel;
        private const string CountEndpointFormat = "/Search()/$count?{0}{1}searchTerm='{2}'&targetFramework='{3}'&includePrerelease={4}&" + SemVerLevel;
        private const string ExactFilterFormat = "tolower(Id)%20eq%20'{0}'";
        private const string ByIdOnlyFormat = "substringof('{0}',tolower(Id))";
        private const string ByTagOnlyFormat = "substringof('{0}',Tags)";
        private const string IdStartsWithFormat = "startswith(tolower(Id),'{0}')";

        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

        private const string QueryDelimiter = "&";

        // constants for /FindPackagesById() endpoint
        private const string FindPackagesByIdFormat = "/FindPackagesById()?id='{0}'&" + SemVerLevel;

        // constants for /Packages() endpoint
        private const string GetPackagesFormat = "/Packages{0}";
        private const string EndpointParenthesis = "()";
        private const string SearchClauseFormat = "({0}%20ne%20null)%20and%20substringof('{1}',tolower({0}))";
        private const string OrFormat = "({0})%20or%20({1})";
        private const string AndFormat = "({0})%20and%20{1}";
        private const string FilterFormat = "$filter={0}";
        private const string OrderByFormat = "$orderby={0}";
        private const string SkipFormat = "$skip={0}";
        private const string TopFormat = "$top={0}";
        private const string TagTermFormat = " {0} ";
        private const string FirstParameterFormat = "?{0}";
        private const string ParameterFormat = "&{0}";
        private const string TagsProperty = "Tags";
        private static readonly string[] _propertiesToSearch = new[]
        {
            IdProperty,
            "Description",
            TagsProperty
        };

        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

        public string BuildSearchUri(
            string searchTerm,
            SearchFilter filters,
            int skip,
            int take)
        {
            return BuildSearchUri(searchTerm, filters, skip, take, false);
        }

        public string BuildSearchUri(
            string searchTerm,
            SearchFilter filters,
            int skip,
            int take,
            bool isCount)
        {
            //////////////////////////////////////////////////////////
            // End - Chocolatey Specific Modification
            //////////////////////////////////////////////////////////

            var shortFormTargetFramework = string.Join(
                "|",
                filters
                    .SupportedFrameworks
                    .Select(targetFramework => NuGetFramework.Parse(targetFramework).GetShortFolderName()));

            var orderBy = BuildOrderBy(filters.OrderBy);

            var filter = BuildFilter(searchTerm, filters, includePropertyClauses: false);

            //////////////////////////////////////////////////////////
            // Start - Chocolatey Specific Modification
            //////////////////////////////////////////////////////////

            if (isCount)
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    CountEndpointFormat,
                    filter != null ? filter + QueryDelimiter : string.Empty,
                    orderBy != null ? orderBy + QueryDelimiter : string.Empty,
                    UriUtility.UrlEncodeOdataParameter(searchTerm),
                    UriUtility.UrlEncodeOdataParameter(shortFormTargetFramework),
                    filters.IncludePrerelease.ToString(CultureInfo.CurrentCulture).ToLowerInvariant());
            }
            else
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    SearchEndpointFormat,
                    filter != null ? filter + QueryDelimiter : string.Empty,
                    orderBy != null ? orderBy + QueryDelimiter : string.Empty,
                    UriUtility.UrlEncodeOdataParameter(searchTerm),
                    UriUtility.UrlEncodeOdataParameter(shortFormTargetFramework),
                    filters.IncludePrerelease.ToString(CultureInfo.CurrentCulture).ToLowerInvariant(),
                    skip,
                    take);
            }

            //////////////////////////////////////////////////////////
            // End - Chocolatey Specific Modification
            //////////////////////////////////////////////////////////
        }

        public string BuildFindPackagesByIdUri(string id)
        {
            var uri = string.Format(
                CultureInfo.InvariantCulture,
                FindPackagesByIdFormat,
                UriUtility.UrlEncodeOdataParameter(id));

            return uri;
        }

        public string BuildGetPackageUri(PackageIdentity package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            if (!package.HasVersion)
            {
                throw new ArgumentException(nameof(package.Version));
            }

            var uri = string.Format(
                CultureInfo.InvariantCulture,
                GetSpecificPackageFormat,
                UriUtility.UrlEncodeOdataParameter(package.Id),
                UriUtility.UrlEncodeOdataParameter(package.Version.ToNormalizedString()));

            return uri;
        }

        public string BuildGetPackagesUri(
            string searchTerm,
            SearchFilter filters,
            int? skip,
            int? take)
        {
            //////////////////////////////////////////////////////////
            // Start - Chocolatey Specific Modification
            //////////////////////////////////////////////////////////

            var filterParameter = BuildFilter(searchTerm, filters, includePropertyClauses: true);

            string orderByParameter = null;
            string skipParameter = null;
            string topParameter = null;

            if (!filters.ExactPackageId)
            {
                orderByParameter = BuildOrderBy(filters.OrderBy);
                skipParameter = BuildSkip(skip);
                topParameter = BuildTop(take);
            }

            //////////////////////////////////////////////////////////
            // End - Chocolatey Specific Modification
            //////////////////////////////////////////////////////////

            // The parenthesis right after the "/Packages" path in the URL are excluded if the filter, orderby, and
            // top parameters are not used. This is a quirk of the NuGet 2.x implementation.
            var useParenthesis = filterParameter != null || orderByParameter != null || topParameter != null;

            // Start building the URI.
            var builder = new StringBuilder();

            builder.AppendFormat(CultureInfo.InvariantCulture, GetPackagesFormat, useParenthesis ? EndpointParenthesis : string.Empty);

            var hasParameters = false;

            // Append each query parameter.
            if (filterParameter != null)
            {
                builder.AppendFormat(
                    CultureInfo.CurrentCulture,
                    hasParameters ? ParameterFormat : FirstParameterFormat,
                    filterParameter);
                hasParameters = true;
            }

            if (orderByParameter != null)
            {
                builder.AppendFormat(
                    CultureInfo.CurrentCulture,
                    hasParameters ? ParameterFormat : FirstParameterFormat,
                    orderByParameter);
                hasParameters = true;
            }

            if (skipParameter != null)
            {
                builder.AppendFormat(
                    CultureInfo.CurrentCulture,
                    hasParameters ? ParameterFormat : FirstParameterFormat,
                    skipParameter);
                hasParameters = true;
            }

            if (topParameter != null)
            {
                builder.AppendFormat(
                    CultureInfo.CurrentCulture,
                    hasParameters ? ParameterFormat : FirstParameterFormat,
                    topParameter);
                hasParameters = true;
            }

            builder.AppendFormat(
                CultureInfo.CurrentCulture,
                hasParameters ? ParameterFormat : FirstParameterFormat,
                SemVerLevel);
            hasParameters = true;

            return builder.ToString();
        }

        private string BuildTop(int? top)
        {
            if (!top.HasValue)
            {
                return null;
            }

            return string.Format(CultureInfo.InvariantCulture, TopFormat, top);
        }

        private string BuildSkip(int? skip)
        {
            if (!skip.HasValue)
            {
                return null;
            }

            return string.Format(CultureInfo.InvariantCulture, SkipFormat, skip);
        }

        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
        private string BuildFilter(string searchTerm, SearchFilter searchFilter, bool includePropertyClauses)
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
        {
            var pieces = new List<string>
            {
                //////////////////////////////////////////////////////////
                // Start - Chocolatey Specific Modification
                //////////////////////////////////////////////////////////
                BuildFieldSearchFilter(searchTerm, searchFilter, includePropertyClauses),
                //////////////////////////////////////////////////////////
                // End - Chocolatey Specific Modification
                //////////////////////////////////////////////////////////
                BuildPropertyFilter(searchFilter.Filter)
            }.AsEnumerable();

            pieces = pieces.Where(p => p != null);

            if (!pieces.Any())
            {
                return null;
            }

            var filter = pieces
                .Aggregate((a, b) => string.Format(CultureInfo.InvariantCulture, AndFormat, a, b));

            return string.Format(CultureInfo.InvariantCulture, FilterFormat, filter);
        }

        private string BuildOrderBy(SearchOrderBy? searchOrderBy)
        {
            string orderBy;
            switch (searchOrderBy)
            {
                case SearchOrderBy.Id:
                    orderBy = IdProperty;
                    break;

                //////////////////////////////////////////////////////////
                // Start - Chocolatey Specific Modification
                //////////////////////////////////////////////////////////

                case SearchOrderBy.DownloadCount:
                    orderBy = string.Format("{0}%20desc,{1}", DownloadCountProperty, IdProperty);
                    break;

                case SearchOrderBy.Version:
                    orderBy = string.Format("{0},{1}%20desc", IdProperty, VersionProperty);
                    break;

                case SearchOrderBy.DownloadCountAndVersion:
                    orderBy = string.Format("{0}%20desc,{1},{2}%20desc", DownloadCountProperty, IdProperty, VersionProperty);
                    break;

                //////////////////////////////////////////////////////////
                // End - Chocolatey Specific Modification
                //////////////////////////////////////////////////////////

                case null:
                    orderBy = null;
                    break;
                default:
                    Debug.Fail("Unhandled value of SearchFilterType");
                    orderBy = null;
                    break;
            }

            if (orderBy != null)
            {
                orderBy = string.Format(CultureInfo.InvariantCulture, OrderByFormat, orderBy);
            }

            return orderBy;
        }

        private string BuildPropertyFilter(SearchFilterType? searchFilterType)
        {
            string filter;
            switch (searchFilterType)
            {
                case SearchFilterType.IsLatestVersion:
                    filter = IsLatestVersionFilterFlag;
                    break;
                case SearchFilterType.IsAbsoluteLatestVersion:
                    filter = IsAbsoluteLatestVersionFilterFlag;
                    break;
                case null:
                    filter = null;
                    break;
                default:
                    Debug.Fail("Unhandled value of SearchFilterType");
                    filter = null;
                    break;
            }

            return filter;
        }

        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
        private string BuildFieldSearchFilter(string searchTerm, SearchFilter searchFilter, bool includePropertyClauses)
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
        {
            if (searchTerm == null)
            {
                return null;
            }

            //////////////////////////////////////////////////////////
            // Start - Chocolatey Specific Modification
            //////////////////////////////////////////////////////////

            if (searchFilter.ExactPackageId)
            {
                return string.Format(CultureInfo.InvariantCulture, ExactFilterFormat, searchTerm);
            }

            var idSearchFilters = new List<string>();

            if (searchFilter.IdStartsWith)
            {
                idSearchFilters.Add(string.Format(CultureInfo.InvariantCulture, IdStartsWithFormat, searchTerm));
            }
            else if (searchFilter.ByIdOnly)
            {
                idSearchFilters.Add(string.Format(CultureInfo.InvariantCulture, ByIdOnlyFormat, searchTerm));
            }

            if (searchFilter.ByTagOnly)
            {
                idSearchFilters.Add(string.Format(CultureInfo.InvariantCulture, ByTagOnlyFormat, searchTerm));
            }

            if (idSearchFilters.Count == 1)
            {
                return idSearchFilters[0];
            }
            else if (idSearchFilters.Count > 1)
            {
                var idFilter = idSearchFilters.Aggregate((a, b) => string.Format(CultureInfo.InvariantCulture, AndFormat, a, b));
                return idFilter;
            }

            if (!includePropertyClauses)
            {
                return null;
            }

            //////////////////////////////////////////////////////////
            // End - Chocolatey Specific Modification
            //////////////////////////////////////////////////////////

            var searchTerms = searchTerm.Split();

            var clauses =
                from term in searchTerms
                from property in _propertiesToSearch
                select BuildFieldSearchClause(term, property);

            var fieldSearch = clauses
                .Aggregate((a, b) => string.Format(CultureInfo.InvariantCulture, OrFormat, a, b));

            return fieldSearch;
        }

        private string BuildFieldSearchClause(string term, string property)
        {
            if (property == TagsProperty)
            {
                term = string.Format(CultureInfo.InvariantCulture, TagTermFormat, term);
            }

            return string.Format(
                CultureInfo.InvariantCulture,
                SearchClauseFormat,
                property,
                UriUtility.UrlEncodeOdataParameter(term));
        }
    }
}
