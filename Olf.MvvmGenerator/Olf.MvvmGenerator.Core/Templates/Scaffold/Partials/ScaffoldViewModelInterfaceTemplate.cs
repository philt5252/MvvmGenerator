using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Scaffold
{
    public partial class ScaffoldViewModelInterfaceTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;

        public ScaffoldViewModelInterfaceTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
        }
    }
}