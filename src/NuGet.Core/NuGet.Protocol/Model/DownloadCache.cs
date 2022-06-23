// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//////////////////////////////////////////////////////////
// Chocolatey Specific Modification
//////////////////////////////////////////////////////////

namespace NuGet.Protocol.Core.Types
{
    public class DownloadCache
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1056:Uri properties should not be strings", Justification = "<Pending>")]
        public string OriginalUrl { get; set; }
        public string FileName { get; set; }
        public string Checksum { get; set; }
    }
}
