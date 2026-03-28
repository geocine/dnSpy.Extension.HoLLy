using System;
using dnlib.DotNet;

namespace HoLLy.dnSpyExtension.Contracts
{
    public interface IHoLLySourceMapService
    {
        bool IsAvailable { get; }
        string CacheFolder { get; }
        bool SupportsParameterDisplayNames { get; }

        string? GetMemberDisplayName(IMemberDef member);
        void SetMemberDisplayName(IMemberDef member, string newName);

        void ExportSourceMap(IAssembly assembly, string path);
        void ImportSourceMap(IAssembly assembly, string path);

        string? GetParameterDisplayName(MethodDef method, int sequence);
        void SetParameterDisplayName(MethodDef method, int sequence, string newName);
    }
}
