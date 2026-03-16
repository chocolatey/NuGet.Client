// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//////////////////////////////////////////////////////////
// Chocolatey Specific Modification
//////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace NuGet.Protocol.Core.Types
{
    public partial interface IPackageSearchMetadata
    {
        string PackageHash { get; }
        string PackageHashAlgorithm { get; }
        long? PackageSize { get; }
        int? VersionDownloadCount { get; }

        bool IsApproved { get; }
        string PackageStatus { get; }
        string PackageSubmittedStatus { get; }
        string PackageTestResultStatus { get; }
        DateTime? PackageTestResultStatusDate { get; }
        string PackageValidationResultStatus { get; }
        DateTime? PackageValidationResultDate { get; }
        DateTime? PackageCleanupResultDate { get; }
        DateTime? PackageReviewedDate { get; }
        DateTime? PackageApprovedDate { get; }
        string PackageReviewer { get; }

        bool IsDownloadCacheAvailable { get; }
        DateTime? DownloadCacheDate { get; }
        IEnumerable<DownloadCache> DownloadCache { get; }

        public string PackagePath { get; }
        string ReleaseNotes { get; }
        Uri ProjectSourceUrl { get; }
        Uri PackageSourceUrl { get; }
        Uri DocsUrl { get; }
        Uri MailingListUrl { get; }
        Uri BugTrackerUrl { get; }
        string DownloadCacheStatus { get; }
        string PackageScanStatus { get; }
        DateTime? PackageScanResultDate { get; }
        string PackageScanFlagResult { get; }

        string AvailableVersionSource { get; set; }
    }
}
