using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates
{
    public partial class ModelFactoryTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected readonly string interfaceObjectName;

        public ModelFactoryTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
            interfaceObjectName = "I" + csFileInfo.ObjectName.Replace("Factory", "");
        }
    }
}