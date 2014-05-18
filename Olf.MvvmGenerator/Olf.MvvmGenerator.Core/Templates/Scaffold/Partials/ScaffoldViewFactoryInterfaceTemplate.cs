using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Scaffold
{
    public partial class ScaffoldViewFactoryInterfaceTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;

        public ScaffoldViewFactoryInterfaceTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
        }
    }
}