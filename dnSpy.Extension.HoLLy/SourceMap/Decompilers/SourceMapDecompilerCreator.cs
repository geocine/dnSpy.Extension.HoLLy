using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using dnSpy.Contracts.App;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Scripting;
using HoLLy.dnSpyExtension.Common.SourceMap;

namespace HoLLy.dnSpyExtension.SourceMap.Decompilers
{
    [Export(typeof(IDecompilerCreator))]
    internal class SourceMapDecompilerCreator : IDecompilerCreator
    {
        private static int failureDialogShown;

        private readonly ISourceMapStorage sourceMapStorage;
        private readonly IServiceLocator serviceLocator;

        [ImportingConstructor]
        public SourceMapDecompilerCreator(ISourceMapStorage sourceMapStorage, IServiceLocator serviceLocator)
        {
            this.sourceMapStorage = sourceMapStorage;
            this.serviceLocator = serviceLocator;
        }

        public IEnumerable<IDecompiler> Create()
        {
            var bootstrapResult = SourceMapDnSpyDecompilerFactory.Create(serviceLocator);
            if (bootstrapResult.FailureMessage is not null && Interlocked.Exchange(ref failureDialogShown, 1) == 0)
                MsgBox.Instance.Show(bootstrapResult.FailureMessage);

            foreach (var decompiler in bootstrapResult.Decompilers)
                yield return new SourceMapDecompilerDecorator(decompiler, sourceMapStorage);
        }
    }
}
