// Copyright (c) 2022-Present Chocolatey Software, Inc.
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

        // NOTE: SupportsInstances is deliberately NOT on this interface. Package Instances have to
        // ship in a 2.x release of Chocolatey CLI, which cannot take breaking changes in the
        // dependencies it uses, and adding a member to this interface breaks every external
        // implementer. It lives only on the concrete ManifestMetadata / PackageBuilder /
        // NuspecReader surface until the next breaking release of Chocolatey CLI (3.x), where it
        // should be added here.
    }
}
