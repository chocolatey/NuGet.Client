// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using NuGet.Packaging.Core;

namespace NuGet.Packaging
{
    /// <summary>
    /// Reads .nuspec files
    /// </summary>
    public partial class NuspecReader : NuspecCoreReaderBase
    {
        public string GetProjectSourceUrl()
        {
            return GetMetadataValue("projectSourceUrl");
        }

        public string GetPackageSourceUrl()
        {
            return GetMetadataValue("packageSourceUrl");
        }

        public string GetDocsUrl()
        {
            return GetMetadataValue("docsUrl");
        }

        public string GetWikiUrl()
        {
            return GetMetadataValue("wikiUrl");
        }

        public string GetMailingListUrl()
        {
            return GetMetadataValue("mailingListUrl");
        }

        public string GetBugTrackerUrl()
        {
            return GetMetadataValue("bugTrackerUrl");
        }

        public string GetReplaces()
        {
            return GetMetadataValue("replaces");
        }

        public string GetProvides()
        {
            return GetMetadataValue("provides");
        }

        public string GetConflicts()
        {
            return GetMetadataValue("conflicts");
        }

        public string GetSoftwareDisplayName()
        {
            return GetMetadataValue("softwareDisplayName");
        }

        public string GetSoftwareDisplayVersion()
        {
            return GetMetadataValue("softwareDisplayVersion");
        }
    }
}
