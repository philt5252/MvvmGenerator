using System.Linq;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Scaffold
{
    public partial class ScaffoldViewModelFactoryTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected readonly string interfaceObjectName;
        protected readonly string interfaceModelName;

        public ScaffoldViewModelFactoryTemplate(CsFileInfo csFileInfo, CsFileInfo modelInterfaceCsFileInfo)
        {
            this.csFileInfo = csFileInfo;
            interfaceObjectName = "I" + csFileInfo.ObjectName.Replace("Factory", "");
            interfaceModelName = modelInterfaceCsFileInfo.ObjectName;

            if(!csFileInfo.Usings.Contains(modelInterfaceCsFileInfo.Namespace))
                csFileInfo.Usings.Add(modelInterfaceCsFileInfo.Namespace);
        }
    }
}