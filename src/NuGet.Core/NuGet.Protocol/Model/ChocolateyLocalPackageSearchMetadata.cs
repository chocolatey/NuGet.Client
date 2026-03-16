// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//////////////////////////////////////////////////////////
// Chocolatey Specific Modification
//////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Packaging;
using NuGet.Protocol.Core.Types;

namespace NuGet.Protocol
{
    public partial class LocalPackageSearchMetadata : IPackageSearchMetadata
    {
        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string PackageHash => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string PackageHashAlgorithm => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public long? PackageSize => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public int? VersionDownloadCount => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public bool IsApproved => false;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string PackageStatus => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string PackageSubmittedStatus => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string PackageTestResultStatus => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public DateTime? PackageTestResultStatusDate => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string PackageValidationResultStatus => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public DateTime? PackageValidationResultDate => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public DateTime? PackageCleanupResultDate => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public DateTime? PackageReviewedDate => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public DateTime? PackageApprovedDate => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string PackageReviewer => null;


        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public bool IsDownloadCacheAvailable
        {
            get
            {
                return false;
            }
        }

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public DateTime? DownloadCacheDate => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public IEnumerable<DownloadCache> DownloadCache
        {
            get
            {
                return Enumerable.Empty<DownloadCache>();
            }
        }

        public NuspecReader GetNuspecReader => _nuspec;

        public string ReleaseNotes
        {
            get
            {
                return _nuspec.GetReleaseNotes();
            }
        }

        public Uri ProjectSourceUrl
        {
            get
            {
                return Convert(_nuspec.GetProjectSourceUrl());
            }
        }

        public Uri PackageSourceUrl
        {
            get
            {
                return Convert(_nuspec.GetPackageSourceUrl());
            }
        }

        public Uri DocsUrl
        {
            get
            {
                return Convert(_nuspec.GetDocsUrl());
            }
        }

        public Uri MailingListUrl
        {
            get
            {
                return Convert(_nuspec.GetMailingListUrl());
            }
        }

        public Uri BugTrackerUrl
        {
            get
            {
                return Convert(_nuspec.GetBugTrackerUrl());
            }
        }

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string DownloadCacheStatus => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string PackageScanStatus => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public DateTime? PackageScanResultDate => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string PackageScanFlagResult => null;

        /// <remarks>
        /// Not applicable to local packages
        /// </remarks>
        public string AvailableVersionSource { get; set; }
    }
}
