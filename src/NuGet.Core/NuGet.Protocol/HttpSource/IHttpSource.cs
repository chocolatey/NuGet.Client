// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using NuGet.Protocol.Core.Types;

namespace NuGet.Protocol
{
    public interface IHttpSource : IDisposable
    {
        /// <summary>The retry handler to use for all HTTP requests.</summary>
        /// <summary>This API is intended only for testing purposes and should not be used in product code.</summary>
        IHttpRetryHandler RetryHandler { get; set; }

        string PackageSource { get; }
        string HttpCacheDirectory { get; set; }

        /// <summary>
        /// Caching Get request.
        /// </summary>
        Task<T> GetAsync<T>(
            HttpSourceCachedRequest request,
            Func<HttpSourceResult, Task<T>> processAsync,
            ILogger log,
            CancellationToken token);

        Task<T> ProcessStreamAsync<T>(
            HttpSourceRequest request,
            Func<Stream, Task<T>> processAsync,
            ILogger log,
            CancellationToken token);

        Task<T> ProcessStreamAsync<T>(
            HttpSourceRequest request,
            Func<Stream, Task<T>> processAsync,
            SourceCacheContext cacheContext,
            ILogger log,
            CancellationToken token);

        Task<T> ProcessResponseAsync<T>(
            HttpSourceRequest request,
            Func<HttpResponseMessage, Task<T>> processAsync,
            ILogger log,
            CancellationToken token);

        Task<T> ProcessResponseAsync<T>(
            HttpSourceRequest request,
            Func<HttpResponseMessage, Task<T>> processAsync,
            SourceCacheContext cacheContext,
            ILogger log,
            CancellationToken token);

        Task<JObject> GetJObjectAsync(HttpSourceRequest request, ILogger log, CancellationToken token);

        Task<T> ProcessHttpStreamAsync<T>(
            HttpSourceRequest request,
            Func<HttpResponseMessage, Task<T>> processAsync,
            ILogger log,
            CancellationToken token);
    }
}
