// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//////////////////////////////////////////////////////////
// Chocolatey Specific Modification
//////////////////////////////////////////////////////////

namespace NuGet.Packaging
{
    using System;
    using System.Collections.Generic;

    public partial interface IPackageMetadata
    {
        Uri ProjectSourceUrl { get; }
        Uri PackageSourceUrl { get; }
        Uri DocsUrl { get; }
        Uri WikiUrl { get; }
        Uri MailingListUrl { get; }
        Uri BugTrackerUrl { get; }
        IEnumerable<string> Replaces { get; }
        IEnumerable<string> Provides { get; }
        IEnumerable<string> Conflicts { get; }

        string SoftwareDisplayName { get; }
        string SoftwareDisplayVersion { get; }
    }
}
