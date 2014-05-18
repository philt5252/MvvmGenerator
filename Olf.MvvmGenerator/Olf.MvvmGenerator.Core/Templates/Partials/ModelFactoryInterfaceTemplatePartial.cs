using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates
{
    public partial class ModelFactoryInterfaceTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected readonly string interfaceObjectName;

        public ModelFactoryInterfaceTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
            interfaceObjectName = csFileInfo.ObjectName.Replace("Factory", "");
        }
    }
}