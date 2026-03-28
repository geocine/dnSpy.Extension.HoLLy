using System;
using System.ComponentModel.Composition;
using dnlib.DotNet;
using dnSpy.Contracts.Documents.Tabs;
using HoLLy.dnSpyExtension.Common.SourceMap;
using HoLLy.dnSpyExtension.Contracts;

namespace HoLLy.dnSpyExtension.SourceMap
{
    [Export(typeof(IHoLLySourceMapService))]
    internal sealed class HoLLySourceMapService : IHoLLySourceMapService
    {
        readonly ISourceMapStorage sourceMapStorage;
        readonly IDocumentTabService documentTabService;

        [ImportingConstructor]
        public HoLLySourceMapService(ISourceMapStorage sourceMapStorage, IDocumentTabService documentTabService)
        {
            this.sourceMapStorage = sourceMapStorage;
            this.documentTabService = documentTabService;
        }

        public bool IsAvailable => true;
        public string CacheFolder => sourceMapStorage.CacheFolder;
        public bool SupportsParameterDisplayNames => true;

        public string? GetMemberDisplayName(IMemberDef member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            return sourceMapStorage.GetName(member);
        }

        public void SetMemberDisplayName(IMemberDef member, string newName)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("newName cannot be empty.", nameof(newName));

            sourceMapStorage.SetName(member, newName);
            RefreshForMember(member);
        }

        public void ExportSourceMap(IAssembly assembly, string path)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path cannot be empty.", nameof(path));

            sourceMapStorage.SaveTo(assembly, path);
        }

        public void ImportSourceMap(IAssembly assembly, string path)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("path cannot be empty.", nameof(path));

            sourceMapStorage.LoadFrom(assembly, path);
            RefreshForAssembly(assembly);
        }

        public string? GetParameterDisplayName(MethodDef method, int sequence)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));
            if (sequence <= 0)
                throw new ArgumentOutOfRangeException(nameof(sequence), "sequence must be a positive metadata parameter sequence.");

            return sourceMapStorage.GetParameterName(method, sequence);
        }

        public void SetParameterDisplayName(MethodDef method, int sequence, string newName)
        {
            if (method is null)
                throw new ArgumentNullException(nameof(method));
            if (sequence <= 0)
                throw new ArgumentOutOfRangeException(nameof(sequence), "sequence must be a positive metadata parameter sequence.");
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("newName cannot be empty.", nameof(newName));

            sourceMapStorage.SetParameterName(method, sequence, newName);
            RefreshForMember(method);
        }

        void RefreshForMember(IMemberDef member)
        {
            var document = documentTabService.DocumentTreeView.FindNode(member.Module)?.Document;
            if (document is not null)
                documentTabService.RefreshModifiedDocument(document);
        }

        void RefreshForAssembly(IAssembly assembly)
        {
            if (assembly is not AssemblyDef assemblyDef)
                return;

            var document =
                documentTabService.DocumentTreeView.FindNode(assemblyDef.ManifestModule)?.Document ??
                documentTabService.DocumentTreeView.FindNode(assemblyDef)?.Document;

            if (document is not null)
                documentTabService.RefreshModifiedDocument(document);
        }
    }
}
