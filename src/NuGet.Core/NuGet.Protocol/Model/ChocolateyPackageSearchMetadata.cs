// Copyright (c) .NET Foundation. All rights reserved.
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
    }
}
