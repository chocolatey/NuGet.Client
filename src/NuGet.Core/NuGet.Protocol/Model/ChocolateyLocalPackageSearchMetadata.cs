// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
