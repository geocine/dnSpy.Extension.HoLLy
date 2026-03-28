using System.ComponentModel.Composition;
using dnlib.DotNet;
using dnSpy.Contracts.App;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Documents.Tabs.DocViewer;
using dnSpy.Contracts.Menus;
using HoLLy.dnSpyExtension.Common;
using HoLLy.dnSpyExtension.Common.SourceMap;
using HoLLy.dnSpyExtension.SourceMap.Decompilers;

namespace HoLLy.dnSpyExtension.SourceMap.Commands
{
    [ExportMenuItem(Header = "Change displayed name", Group = Constants.ContextMenuGroupEdit)]
    internal class RenameDisplayed : MenuItemBase
    {
        private readonly ISourceMapStorage sourceMapStorage;
        private readonly IDecompilerService decompilerService;

        [ImportingConstructor]
        public RenameDisplayed(ISourceMapStorage sourceMapStorage, IDecompilerService decompilerService)
        {
            this.sourceMapStorage = sourceMapStorage;
            this.decompilerService = decompilerService;
        }

        public override void Execute(IMenuItemContext context)
        {
            var textReference = context.Find<TextReference>();
            var docViewer = context.Find<IDocumentViewer>();
            var documentTabService = docViewer?.DocumentTab?.DocumentTabService;

            if (TryGetMappedParameter(textReference?.Reference, out var method, out var sequence, out var currentParameterName)) {
                string? newParameterName = MsgBox.Instance.Ask<string>(
                    "Name:",
                    defaultText: sourceMapStorage.GetParameterName(method, sequence) ?? currentParameterName,
                    title: $"New name for parameter {currentParameterName} in {method}");

                if (string.IsNullOrEmpty(newParameterName))
                    return;

                sourceMapStorage.SetParameterName(method, sequence, newParameterName!);

                var parameterDocument = documentTabService?.DocumentTreeView.FindNode(method.Module)?.Document;
                if (parameterDocument is not null)
                    documentTabService!.RefreshModifiedDocument(parameterDocument);
                return;
            }

            if (textReference?.Reference is not IMemberDef m)
                return;

            var mappedMember = SourceMapUtils.GetDefToMap(m);
            string? newName = MsgBox.Instance.Ask<string>(
                "Name:",
                defaultText: sourceMapStorage.GetName(mappedMember) ?? mappedMember.Name,
                title: $"New name for {mappedMember}");

            if (string.IsNullOrEmpty(newName))
                return;

            sourceMapStorage.SetName(m, newName!);

            var document = documentTabService?.DocumentTreeView.FindNode(m.Module)?.Document;
            if (document is not null)
                documentTabService!.RefreshModifiedDocument(document);
        }

        public override bool IsVisible(IMenuItemContext context)
        {
            if (!(decompilerService.Decompiler is SourceMapDecompilerDecorator))
                return false;

            var tf = context.Find<TextReference>();
            return tf?.Reference is IMemberDef || TryGetMappedParameter(tf?.Reference, out _, out _, out _);
        }

        private static bool TryGetMappedParameter(object? reference, out MethodDef method, out int sequence, out string currentName)
        {
            switch (reference) {
                case SourceParameter sourceParameter when TryGetMappedParameter(sourceParameter.Parameter, sourceParameter.Name, out method, out sequence, out currentName):
                    return true;

                case ISourceVariable sourceVariable when sourceVariable.IsParameter && !sourceVariable.IsDecompilerGenerated &&
                                                        TryGetMappedParameter(sourceVariable.Variable as Parameter, sourceVariable.Name, out method, out sequence, out currentName):
                    return true;

                case Parameter parameter when TryGetMappedParameter(parameter, parameter.Name, out method, out sequence, out currentName):
                    return true;
            }

            method = null!;
            sequence = 0;
            currentName = string.Empty;
            return false;
        }

        private static bool TryGetMappedParameter(Parameter? parameter, string fallbackName, out MethodDef method, out int sequence, out string currentName)
        {
            if (parameter?.ParamDef is ParamDef parameterDef &&
                parameterDef.Sequence > 0 &&
                (parameterDef.DeclaringMethod ?? parameter.Method) is MethodDef declaringMethod)
            {
                method = declaringMethod;
                sequence = parameterDef.Sequence;
                currentName = fallbackName;
                return true;
            }

            method = null!;
            sequence = 0;
            currentName = string.Empty;
            return false;
        }
    }
}
