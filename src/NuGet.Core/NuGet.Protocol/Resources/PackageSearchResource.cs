// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NuGet.Protocol.Core.Types
{
    public abstract class PackageSearchResource : INuGetResource
    {
        /// <summary>
        /// Retrieves search results
        /// </summary>
        public abstract Task<IEnumerable<IPackageSearchMetadata>> SearchAsync(
            string searchTerm,
            SearchFilter filters,
            int skip,
            int take,
            Common.ILogger log,
            CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves the total number of search results
        /// </summary>
        public abstract Task<int> SearchCountAsync(
            string searchTerm,
            SearchFilter filters,
            Common.ILogger log,
            CancellationToken cancellationToken);
    }
}
