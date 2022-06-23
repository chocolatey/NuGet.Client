// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using NuGet.Protocol.Core.Types;

namespace NuGet.PackageManagement.UI.Test
{
    partial class TestPackageSearchMetadata : IPackageSearchMetadata
    {
        public string PackageHash { get; set; }
        public string PackageHashAlgorithm { get; set; }
        public long? PackageSize { get; set; }
        public int? VersionDownloadCount { get; set; }

        public bool IsApproved { get; set; }
        public string PackageStatus { get; set; }
        public string PackageSubmittedStatus { get; set; }
        public string PackageTestResultStatus { get; set; }
        public DateTime? PackageTestResultStatusDate { get; set; }
        public string PackageValidationResultStatus { get; set; }
        public DateTime? PackageValidationResultDate { get; set; }
        public DateTime? PackageCleanupResultDate { get; set; }
        public DateTime? PackageReviewedDate { get; set; }
        public DateTime? PackageApprovedDate { get; set; }
        public string PackageReviewer { get; set; }

        public bool IsDownloadCacheAvailable { get; set; }
        public DateTime? DownloadCacheDate { get; set; }
        public IEnumerable<DownloadCache> DownloadCache { get; set; }
    }
}
