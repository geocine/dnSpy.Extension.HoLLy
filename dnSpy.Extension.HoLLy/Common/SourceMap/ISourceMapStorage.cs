using dnlib.DotNet;

namespace HoLLy.dnSpyExtension.Common.SourceMap
{
    internal interface ISourceMapStorage
    {
        string CacheFolder { get; }

        string? GetName(IMemberDef member);
        void SetName(IMemberDef member, string name);
        string? GetParameterName(MethodDef method, int sequence);
        void SetParameterName(MethodDef method, int sequence, string name);
        void SaveTo(IAssembly assembly, string location);
        void LoadFrom(IAssembly assembly, string location);
    }
}
