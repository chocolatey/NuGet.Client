// Copyright (c) .NET Foundation. All rights reserved.
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
    public partial class ManifestMetadata : IPackageMetadata
    {
        private IEnumerable<string> _replaces = Enumerable.Empty<string>();
        private IEnumerable<string> _provides = Enumerable.Empty<string>();
        private IEnumerable<string> _conflicts = Enumerable.Empty<string>();

        private string _projectSourceUrl;
        private string _packageSourceUrl;
        private string _docsUrl;
        private string _wikiUrl;
        private string _mailingListUrl;
        private string _bugTrackerUrl;

        private void FinishContruction(IPackageMetadata copy)
        {
            _projectSourceUrl = copy.ProjectSourceUrl?.OriginalString;
            _packageSourceUrl = copy.PackageSourceUrl?.OriginalString;
            _docsUrl = copy.DocsUrl?.OriginalString;
            _wikiUrl = copy.WikiUrl?.OriginalString;
            _mailingListUrl = copy.MailingListUrl?.OriginalString;
            _bugTrackerUrl = copy.BugTrackerUrl?.OriginalString;
            Replaces = copy.Replaces;
            Provides = copy.Provides;
            Conflicts = copy.Conflicts;
            SoftwareDisplayName = copy.SoftwareDisplayName;
            SoftwareDisplayVersion = copy.SoftwareDisplayVersion;
        }

        public void SetProjectSourceUrl(string projectSourceUrl)
        {
            _projectSourceUrl = projectSourceUrl;
        }

        public Uri ProjectSourceUrl
        {
            get
            {
                if (_projectSourceUrl == null)
                {
                    return null;
                }

                return new Uri(_projectSourceUrl);
            }
        }

        public void SetPackageSourceUrl(string packageSourceUrl)
        {
            _packageSourceUrl = packageSourceUrl;
        }

        public Uri PackageSourceUrl
        {
            get
            {
                if (_packageSourceUrl == null)
                {
                    return null;
                }

                return new Uri(_packageSourceUrl);
            }
        }

        public void SetDocsUrl(string docsUrl)
        {
            _docsUrl = docsUrl;
        }

        public Uri DocsUrl
        {
            get
            {
                if (_docsUrl == null)
                {
                    return null;
                }

                return new Uri(_docsUrl);
            }
        }

        public void SetWikiUrl(string wikiUrl)
        {
            _wikiUrl = wikiUrl;
        }

        public Uri WikiUrl
        {
            get
            {
                if (_wikiUrl == null)
                {
                    return null;
                }

                return new Uri(_wikiUrl);
            }
        }

        public void SetMailingListUrl(string mailingListUrl)
        {
            _mailingListUrl = mailingListUrl;
        }

        public Uri MailingListUrl
        {
            get
            {
                if (_mailingListUrl == null)
                {
                    return null;
                }

                return new Uri(_mailingListUrl);
            }
        }

        public void SetBugTrackerUrl(string bugTrackerUrl)
        {
            _bugTrackerUrl = bugTrackerUrl;
        }

        public Uri BugTrackerUrl
        {
            get
            {
                if (_bugTrackerUrl == null)
                {
                    return null;
                }

                return new Uri(_bugTrackerUrl);
            }
        }

        public IEnumerable<string> Replaces
        {
            get { return _replaces; }
            set { _replaces = value ?? Enumerable.Empty<string>(); }
        }

        public IEnumerable<string> Provides
        {
            get { return _provides; }
            set { _provides = value ?? Enumerable.Empty<string>(); }
        }

        public IEnumerable<string> Conflicts
        {
            get { return _conflicts; }
            set { _conflicts = value ?? Enumerable.Empty<string>(); }
        }

        public string SoftwareDisplayName { get; set; }

        public string SoftwareDisplayVersion { get; set; }
    }
}
