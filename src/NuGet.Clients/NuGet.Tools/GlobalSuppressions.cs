// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "VSTHRD011:Use AsyncLazy<T>", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.ShowErrorsCommand.#ctor(System.IServiceProvider)")]
[assembly: SuppressMessage("Build", "CA1031:Modify 'Flush' to catch a more specific allowed exception type, or rethrow the exception.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.DataStreamFromComStream.Flush")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'void FontAndColorsRegistrationAttribute.Register(RegistrationContext context)', validate parameter 'context' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.FontAndColorsRegistrationAttribute.Register(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'void FontAndColorsRegistrationAttribute.Unregister(RegistrationContext context)', validate parameter 'context' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.FontAndColorsRegistrationAttribute.Unregister(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)")]
[assembly: SuppressMessage("Build", "CA2000:Call System.IDisposable.Dispose on object created by 'new PackageManagerWindowPane(control)' before all references to it are out of scope.", Justification = "The responsibility to dispose the object is transferred to another object or wrapper that's created in the method and returned to the caller", Scope = "member", Target = "~M:NuGetVSExtension.NuGetPackage.CreateDocWindowAsync(EnvDTE.Project,System.String,Microsoft.VisualStudio.Shell.Interop.IVsHierarchy,System.UInt32)~System.Threading.Tasks.Task{Microsoft.VisualStudio.Shell.Interop.IVsWindowFrame}")]
[assembly: SuppressMessage("Build", "CA2000:Call System.IDisposable.Dispose on object created by 'new PackageManagerWindowPane(control)' before all references to it are out of scope.", Justification = "The responsibility to dispose the object is transferred to another object or wrapper that's created in the method and returned to the caller", Scope = "member", Target = "~M:NuGetVSExtension.NuGetPackage.CreateDocWindowForSolutionAsync~System.Threading.Tasks.Task{Microsoft.VisualStudio.Shell.Interop.IVsWindowFrame}")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'int NuGetPackage.LoadUserOptions(IVsSolutionPersistence pPersistence, uint grfLoadOpts)', validate parameter 'pPersistence' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.NuGetPackage.LoadUserOptions(Microsoft.VisualStudio.Shell.Interop.IVsSolutionPersistence,System.UInt32)~System.Int32")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'int NuGetPackage.SaveUserOptions(IVsSolutionPersistence pPersistence)', validate parameter 'pPersistence' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.NuGetPackage.SaveUserOptions(Microsoft.VisualStudio.Shell.Interop.IVsSolutionPersistence)~System.Int32")]
[assembly: SuppressMessage("Build", "CA1031:Modify 'ShowOptionPageSafe' to catch a more specific allowed exception type, or rethrow the exception.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.NuGetPackage.ShowOptionPageSafe(System.Type)")]
[assembly: SuppressMessage("Build", "CA1307:The behavior of 'string.StartsWith(string)' could vary based on the current user's locale settings. Replace this call in 'NuGetVSExtension.NuGetStaticSearchResult.NuGetStaticSearchResult(string, NuGetVSExtension.NuGetSearchProvider, Microsoft.VisualStudio.Shell.OleMenuCommand)' with a call to 'string.StartsWith(string, System.StringComparison)'.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.NuGetStaticSearchResult.#ctor(System.String,NuGetVSExtension.NuGetSearchProvider,Microsoft.VisualStudio.Shell.OleMenuCommand)")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'void ProvideExpressLoadKeyAttribute.Register(RegistrationContext context)', validate parameter 'context' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.ProvideExpressLoadKeyAttribute.Register(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)")]
[assembly: SuppressMessage("Build", "CA1822:Member RegKeyName does not access instance data and can be marked as static (Shared in VisualBasic)", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.ProvideExpressLoadKeyAttribute.RegKeyName(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)~System.String")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'string ProvideExpressLoadKeyAttribute.RegKeyName(RegistrationContext context)', validate parameter 'context' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.ProvideExpressLoadKeyAttribute.RegKeyName(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)~System.String")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'void ProvideExpressLoadKeyAttribute.Unregister(RegistrationContext context)', validate parameter 'context' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.ProvideExpressLoadKeyAttribute.Unregister(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)")]
[assembly: SuppressMessage("Build", "CA1303:Method 'ProvideSearchProviderAttribute.ProvideSearchProviderAttribute(Type providerType, string providerName)' passes a literal string as parameter 'message' of a call to 'ArgumentException.ArgumentException(string message)'. Retrieve the following string(s) from a resource table instead: \"'providerName' cannot be null or empty.\".", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.ProvideSearchProviderAttribute.#ctor(System.Type,System.String)")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'void ProvideSearchProviderAttribute.Register(RegistrationContext context)', validate parameter 'context' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.ProvideSearchProviderAttribute.Register(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)")]
[assembly: SuppressMessage("Build", "CA1062:In externally visible method 'void ProvideSearchProviderAttribute.Unregister(RegistrationContext context)', validate parameter 'context' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.ProvideSearchProviderAttribute.Unregister(Microsoft.VisualStudio.Shell.RegistrationAttribute.RegistrationContext)")]
[assembly: SuppressMessage("Build", "CA1031:Modify 'ReadUserOptions' to catch a more specific allowed exception type, or rethrow the exception.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.SolutionUserOptions.ReadUserOptions(Microsoft.VisualStudio.OLE.Interop.IStream,System.String)~System.Int32")]
[assembly: SuppressMessage("Build", "CA1031:Modify 'WriteUserOptions' to catch a more specific allowed exception type, or rethrow the exception.", Justification = "<Pending>", Scope = "member", Target = "~M:NuGetVSExtension.SolutionUserOptions.WriteUserOptions(Microsoft.VisualStudio.OLE.Interop.IStream,System.String)~System.Int32")]
[assembly: SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize", Justification = "IVsPackage.Close() method invokes overridden NuGetPackage.Dispose() method which internally invokes GC.SuppressFinalize() method.", Scope = "member", Target = "~M:NuGetVSExtension.NuGetPackage.Dispose(System.Boolean)")]
[assembly: SuppressMessage("Design", "CA1001:Types that own disposable fields should be disposable", Justification = "IVsPackage.Close() method invokes overridden NuGetPackage.Dispose() method upon closing the IDE.", Scope = "type", Target = "~T:NuGetVSExtension.NuGetPackage")]
