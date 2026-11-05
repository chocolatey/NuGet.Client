// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//////////////////////////////////////////////////////////
// Chocolatey Specific Modification
//////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGet.Packaging
{
    public partial class PackageBuilder : IPackageMetadata
    {
        public Uri ProjectSourceUrl { get; set; }
        public Uri PackageSourceUrl { get; set; }
        public Uri DocsUrl { get; set; }
        public Uri WikiUrl { get; set; }
        public Uri MailingListUrl { get; set; }
        public Uri BugTrackerUrl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
        public ISet<string> Replaces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
        public ISet<string> Provides { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
        public ISet<string> Conflicts { get; set; }
        public string SoftwareDisplayName { get; set; }
        public string SoftwareDisplayVersion { get; set; }
        public bool SupportsInstances { get; set; }

        IEnumerable<string> IPackageMetadata.Replaces
        {
            get
            {
                return Replaces;
            }
        }

        IEnumerable<string> IPackageMetadata.Provides
        {
            get
            {
                return Provides;
            }
        }

        IEnumerable<string> IPackageMetadata.Conflicts
        {
            get
            {
                return Conflicts;
            }
        }

        private void FinishPopulate(IPackageMetadata metadata)
        {
            ProjectSourceUrl = metadata.ProjectSourceUrl;
            PackageSourceUrl = metadata.PackageSourceUrl;
            DocsUrl = metadata.DocsUrl;
            WikiUrl = metadata.WikiUrl;
            MailingListUrl = metadata.MailingListUrl;
            BugTrackerUrl = metadata.BugTrackerUrl;
            SoftwareDisplayName = metadata.SoftwareDisplayName;
            SoftwareDisplayVersion = metadata.SoftwareDisplayVersion;

            // SupportsInstances is not on IPackageMetadata, as adding it would break external
            // implementers and Chocolatey CLI 2.x cannot take a breaking change in its dependencies,
            // so carry it across from the concrete types that hold it. Any other implementer yields false.
            SupportsInstances = (metadata as ManifestMetadata)?.SupportsInstances
                ?? (metadata as PackageBuilder)?.SupportsInstances
                ?? false;

            Replaces.AddRange(metadata.Replaces);
            Provides.AddRange(metadata.Provides);
            Conflicts.AddRange(metadata.Conflicts);
        }

        private void FinishContruction()
        {
            Replaces = new HashSet<string>();
            Provides = new HashSet<string>();
            Conflicts = new HashSet<string>();
        }
    }
}
