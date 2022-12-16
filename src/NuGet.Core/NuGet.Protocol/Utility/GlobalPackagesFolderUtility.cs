// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Packaging.PackageExtraction;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Core.Types;

namespace NuGet.Protocol
{
    public static class GlobalPackagesFolderUtility
    {
        private const int BufferSize = 8192;

        public static DownloadResourceResult GetPackage(PackageIdentity packageIdentity, string globalPackagesFolder)
        {
            if (packageIdentity == null)
            {
                throw new ArgumentNullException(nameof(packageIdentity));
            }

            if (globalPackagesFolder == null)
            {
                throw new ArgumentNullException(nameof(globalPackagesFolder));
            }

            var defaultPackagePathResolver = new VersionFolderPathResolver(globalPackagesFolder);

            var nupkgMetadataPath = defaultPackagePathResolver.GetNupkgMetadataPath(packageIdentity.Id, packageIdentity.Version);
            var hashPath = defaultPackagePathResolver.GetHashPath(packageIdentity.Id, packageIdentity.Version);
            var installPath = defaultPackagePathResolver.GetInstallPath(
                    packageIdentity.Id,
                    packageIdentity.Version);
            var nupkgPath = defaultPackagePathResolver.GetPackageFilePath(
                packageIdentity.Id,
                packageIdentity.Version);

            if (File.Exists(nupkgMetadataPath))
            {
                return CreateDownloadResourceResult(nupkgPath, installPath);
            }
            else if (File.Exists(hashPath))
            {
                LocalFolderUtility.GenerateNupkgMetadataFile(nupkgPath, installPath, hashPath, nupkgMetadataPath);
                return CreateDownloadResourceResult(nupkgPath, installPath);
            }

            return null;
        }

        private static DownloadResourceResult CreateDownloadResourceResult(string nupkgPath, string installPath)
        {
            Stream stream = null;
            PackageReaderBase packageReader = null;
            try
            {
                stream = File.Open(nupkgPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                packageReader = new PackageFolderReader(installPath);
                return new DownloadResourceResult(stream, packageReader, source: null) { SignatureVerified = true };
            }
            catch
            {
                if (stream != null)
                {
                    stream.Dispose();
                }

                if (packageReader != null)
                {
                    packageReader.Dispose();
                }

                throw;
            }
        }

        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
        public static async Task<DownloadResourceResult> AddPackageAsync(
            string source,
            PackageIdentity packageIdentity,
            Stream packageStream,
            string globalPackagesFolder,
            Guid parentId,
            ClientPolicyContext clientPolicyContext,
            ILogger logger,
            CancellationToken token)
        {
            return await AddPackageAsync(source, packageIdentity, packageStream, globalPackagesFolder, parentId,
                clientPolicyContext, logger, token, null);
        }

        public static async Task<DownloadResourceResult> AddPackageAsync(
            string source,
            PackageIdentity packageIdentity,
            Stream packageStream,
            string globalPackagesFolder,
            Guid parentId,
            ClientPolicyContext clientPolicyContext,
            ILogger logger,
            CancellationToken token,
            ChocolateyProgressInfo progressInfo)
        {
            if (packageIdentity == null)
            {
                throw new ArgumentNullException(nameof(packageIdentity));
            }

            if (packageStream == null)
            {
                throw new ArgumentNullException(nameof(packageStream));
            }

            if (globalPackagesFolder == null)
            {
                throw new ArgumentNullException(nameof(globalPackagesFolder));
            }

            // The following call adds it to the global packages folder.
            // Addition is performed using ConcurrentUtils, such that,
            // multiple processes may add at the same time

            var extractionContext = new PackageExtractionContext(
               PackageSaveMode.Defaultv3,
               PackageExtractionBehavior.XmlDocFileSaveMode,
               clientPolicyContext,
               logger);

            var versionFolderPathResolver = new VersionFolderPathResolver(globalPackagesFolder);

            using (var progressPackageStream = new ChocolateyProgressStream(packageStream))
            {
                progressPackageStream.ReadProgress += (sender, progress, totalProgress) =>
                {
                    if (progressInfo.Length != null && ChocolateyProgressInfo.ShouldDisplayDownloadProgress && !progressInfo.Completed)
                    {
                        var percentComplete = ((double)totalProgress / (double)progressInfo.Length * 100);
                        var progressString =
                            $"Progress: {progressInfo.Operation} {progressInfo.Identity.Id} {progressInfo.Identity.Version}... {(percentComplete.ToString("##"))}";
                        // http://stackoverflow.com/a/888569/18475
                        Console.Write("\r{0}%", progressString);
                        if (totalProgress == progressInfo.Length)
                        {
                            Console.WriteLine("");
                            progressInfo.Completed = true;
                        }
                    }
                };
                await PackageExtractor.InstallFromSourceAsync(
                    source,
                    packageIdentity,
                    stream => progressPackageStream.CopyToAsync(stream, BufferSize, token),
                    versionFolderPathResolver,
                    extractionContext,
                    token,
                    parentId);

            }

            var package = GetPackage(packageIdentity, globalPackagesFolder);

            Debug.Assert(package.PackageStream.CanSeek);
            Debug.Assert(package.PackageReader != null);

            return package;
        }
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
    }
}
