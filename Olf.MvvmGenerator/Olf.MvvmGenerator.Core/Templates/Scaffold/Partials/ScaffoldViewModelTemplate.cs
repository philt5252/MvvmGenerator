using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Scaffold
{
    public partial class ScaffoldViewModelTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected readonly string interfaceModelName;

        public ScaffoldViewModelTemplate(CsFileInfo csFileInfo, CsFileInfo modelInterfaceCsFileInfo)
        {
            this.csFileInfo = csFileInfo;
            interfaceModelName = modelInterfaceCsFileInfo.ObjectName;

            if (!csFileInfo.Usings.Contains(modelInterfaceCsFileInfo.Namespace))
                csFileInfo.Usings.Add(modelInterfaceCsFileInfo.Namespace);
        }
    }
}