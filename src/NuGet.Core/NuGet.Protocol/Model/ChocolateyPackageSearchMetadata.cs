// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//////////////////////////////////////////////////////////
// Chocolatey Specific Modification
//////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace NuGet.Protocol
{
    public partial class PackageSearchMetadata : IPackageSearchMetadata
    {
        //TODO - if CCR gets updated to support v3 api, add these as json elements
        [JsonIgnore]
        public string PackageHash { get; set; }
        [JsonIgnore]
        public string PackageHashAlgorithm { get; set; }
        [JsonIgnore]
        public long? PackageSize { get; set; }
        [JsonIgnore]
        public int? VersionDownloadCount { get; set; }

        [JsonIgnore]
        public bool IsApproved { get; set; }
        [JsonIgnore]
        public string PackageStatus { get; set; }
        [JsonIgnore]
        public string PackageSubmittedStatus { get; set; }
        [JsonIgnore]
        public string PackageTestResultStatus { get; set; }
        [JsonIgnore]
        public DateTime? PackageTestResultStatusDate { get; set; }
        [JsonIgnore]
        public string PackageValidationResultStatus { get; set; }
        [JsonIgnore]
        public DateTime? PackageValidationResultDate { get; set; }
        [JsonIgnore]
        public DateTime? PackageCleanupResultDate { get; set; }
        [JsonIgnore]
        public DateTime? PackageReviewedDate { get; set; }
        [JsonIgnore]
        public DateTime? PackageApprovedDate { get; set; }
        [JsonIgnore]
        public string PackageReviewer { get; set; }

        [JsonIgnore]
        public bool IsDownloadCacheAvailable { get; set; }
        [JsonIgnore]
        public DateTime? DownloadCacheDate { get; set; }
        [JsonIgnore]
        public IEnumerable<DownloadCache> DownloadCache { get; set; }

        [JsonIgnore]
        public string PackagePath => null;
        [JsonIgnore]
        public string ReleaseNotes { get; set; }
        [JsonIgnore]
        public Uri ProjectSourceUrl { get; set; }
        [JsonIgnore]
        public Uri PackageSourceUrl { get; set; }
        [JsonIgnore]
        public Uri DocsUrl { get; set; }
        [JsonIgnore]
        public Uri MailingListUrl { get; set; }
        [JsonIgnore]
        public Uri BugTrackerUrl { get; set; }
        [JsonIgnore]
        public string DownloadCacheStatus { get; set; }
        [JsonIgnore]
        public string PackageScanStatus { get; set; }
        [JsonIgnore]
        public DateTime? PackageScanResultDate { get; set; }
        [JsonIgnore]
        public string PackageScanFlagResult { get; set; }
        [JsonIgnore]
        public string AvailableVersionSource { get; set; }
    }
}
