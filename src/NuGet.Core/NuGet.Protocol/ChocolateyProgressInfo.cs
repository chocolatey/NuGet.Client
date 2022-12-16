// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Packaging.Core;

namespace NuGet.Protocol
{
    public class ChocolateyProgressInfo
    {
        public ChocolateyProgressInfo(PackageIdentity identity, long? length = null, string operation = "")
        {
            Operation = operation;
            Length = length;
            Identity = identity;
        }

        public string Operation { get; set; }
        public PackageIdentity Identity { get; set; }
        public long? Length { get; set; }
        public static bool ShouldDisplayDownloadProgress { get; set; }
        public bool Completed { get; set; }
    }
}
