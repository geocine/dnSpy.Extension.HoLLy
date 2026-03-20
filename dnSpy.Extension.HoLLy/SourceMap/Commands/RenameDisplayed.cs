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

            var documentTabService = docViewer?.DocumentTab?.DocumentTabService;
            var document = documentTabService?.DocumentTreeView.FindNode(m.Module)?.Document;
            if (document is not null)
                documentTabService!.RefreshModifiedDocument(document);
        }

        public override bool IsVisible(IMenuItemContext context)
        {
            if (!(decompilerService.Decompiler is SourceMapDecompilerDecorator))
                return false;

            var tf = context.Find<TextReference>();
            return tf?.Reference is IMemberDef;
        }
    }
}
