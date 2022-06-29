// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Net;

namespace NuGet.Configuration
{
    public partial class ProxyCache : IProxyCache, IProxyCredentialCache
    {
        private IWebProxy _overrideProxy;
        private bool _isProxyOverridden = false;

        public void Override(IWebProxy proxy)
        {
            _overrideProxy = proxy;
            _isProxyOverridden = true;
        }

        public void ClearOverriding()
        {
            _overrideProxy = null;
            _isProxyOverridden = false;
        }
    }
}
