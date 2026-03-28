using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Scripting;

namespace HoLLy.dnSpyExtension.SourceMap.Decompilers
{
    internal static class SourceMapDnSpyDecompilerFactory
    {
        private const string SettingsServiceTypeName = "dnSpy.Decompiler.ILSpy.Core.Settings.DecompilerSettingsService";
        private const string FailureMessagePrefix = "SourceMap decompilers could not be initialized, so SourceMap decompiler entries are unavailable in this session.";

        private static readonly string[] ProviderTypeNames = {
            "dnSpy.Decompiler.ILSpy.Core.CSharp.DecompilerProvider",
            "dnSpy.Decompiler.ILSpy.Core.IL.DecompilerProvider",
            "dnSpy.Decompiler.ILSpy.Core.ILAst.DecompilerProvider",
            "dnSpy.Decompiler.ILSpy.Core.VisualBasic.DecompilerProvider",
        };

        public static SourceMapDnSpyDecompilerFactoryResult Create(IServiceLocator serviceLocator)
        {
            if (serviceLocator is null)
                throw new ArgumentNullException(nameof(serviceLocator));

            Type? settingsServiceType = FindType(SettingsServiceTypeName);
            if (settingsServiceType is null)
                return Fail("Could not find dnSpy's ILSpy decompiler settings type.");

            object? decompilerSettingsService = TryResolveDecompilerSettingsService(serviceLocator, settingsServiceType);
            if (decompilerSettingsService is null)
                return Fail("Could not resolve dnSpy's ILSpy decompiler settings service.");

            var decompilers = new List<IDecompiler>();
            foreach (string providerTypeName in ProviderTypeNames)
                TryAddProviderDecompilers(providerTypeName, decompilerSettingsService, decompilers);

            if (decompilers.Count == 0)
                return Fail("Could not create SourceMap decompilers from dnSpy's ILSpy providers.");

            return new SourceMapDnSpyDecompilerFactoryResult(decompilers, null);
        }

        private static object? TryResolveDecompilerSettingsService(IServiceLocator serviceLocator, Type settingsServiceType)
        {
            MethodInfo? tryResolveMethod = typeof(IServiceLocator).GetMethod(nameof(IServiceLocator.TryResolve), BindingFlags.Instance | BindingFlags.Public);
            if (tryResolveMethod is null || !tryResolveMethod.IsGenericMethodDefinition) {
                LogFailure("Could not find IServiceLocator.TryResolve<T>().");
                return null;
            }

            try
            {
                return tryResolveMethod.MakeGenericMethod(settingsServiceType).Invoke(serviceLocator, null);
            }
            catch (Exception ex)
            {
                LogFailure("Failed to resolve dnSpy's ILSpy decompiler settings service.", UnwrapReflectionException(ex));
                return null;
            }
        }

        private static void TryAddProviderDecompilers(string providerTypeName, object decompilerSettingsService, List<IDecompiler> decompilers)
        {
            Type? providerType = FindType(providerTypeName);
            if (providerType is null) {
                LogFailure($"Could not find ILSpy decompiler provider type '{providerTypeName}'.");
                return;
            }

            try
            {
                if (Activator.CreateInstance(providerType, new[] { decompilerSettingsService }) is not IDecompilerProvider provider) {
                    LogFailure($"Could not create '{providerTypeName}' as an {nameof(IDecompilerProvider)}.");
                    return;
                }

                foreach (IDecompiler decompiler in provider.Create())
                    decompilers.Add(decompiler);
            }
            catch (Exception ex)
            {
                LogFailure($"Failed to create decompilers from '{providerTypeName}'.", UnwrapReflectionException(ex));
            }
        }

        private static SourceMapDnSpyDecompilerFactoryResult Fail(string reason)
        {
            LogFailure(reason);
            return new SourceMapDnSpyDecompilerFactoryResult(Array.Empty<IDecompiler>(), FailureMessagePrefix + Environment.NewLine + Environment.NewLine + "Reason: " + reason);
        }

        private static void LogFailure(string message, Exception? exception = null)
        {
            const string Prefix = "[SourceMap] ";
            Debug.WriteLine(Prefix + message);
            if (exception is not null)
                Debug.WriteLine(exception);
        }

        private static Exception UnwrapReflectionException(Exception exception)
        {
            if (exception is TargetInvocationException targetInvocationException && targetInvocationException.InnerException is Exception innerException)
                return innerException;

            return exception;
        }

        private static Type? FindType(string fullName)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                Type? type = assembly.GetType(fullName, throwOnError: false);
                if (type is not null)
                    return type;
            }

            return null;
        }
    }

    internal sealed class SourceMapDnSpyDecompilerFactoryResult
    {
        public IReadOnlyList<IDecompiler> Decompilers { get; }
        public string? FailureMessage { get; }

        public SourceMapDnSpyDecompilerFactoryResult(IReadOnlyList<IDecompiler> decompilers, string? failureMessage)
        {
            Decompilers = decompilers ?? throw new ArgumentNullException(nameof(decompilers));
            FailureMessage = failureMessage;
        }
    }
}
