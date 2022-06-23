// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace NuGet.Protocol.Core.Types
{
    public partial interface IPackageSearchMetadata
    {
        /*
        Created = p.Created,
        GalleryDetailsUrl = siteRoot + "packages/" + p.PackageRegistration.Id + "/" + p.Version,
        IsPrerelease = p.IsPrerelease,
        LastUpdated = p.LastUpdated,
        */

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
    }
}
