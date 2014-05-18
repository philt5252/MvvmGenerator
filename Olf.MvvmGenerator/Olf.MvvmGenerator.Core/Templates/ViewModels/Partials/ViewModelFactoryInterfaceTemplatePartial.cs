using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.ViewModels
{
    public partial class ViewModelFactoryInterfaceTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected readonly string interfaceObjectName;

        public ViewModelFactoryInterfaceTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
            interfaceObjectName = csFileInfo.ObjectName.Replace("Factory", "");
        }
    }
}