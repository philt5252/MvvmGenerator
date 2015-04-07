using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.ViewFactory
{
    public partial class ViewFactoryInterfaceTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;

        public ViewFactoryInterfaceTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
        }
    }
}