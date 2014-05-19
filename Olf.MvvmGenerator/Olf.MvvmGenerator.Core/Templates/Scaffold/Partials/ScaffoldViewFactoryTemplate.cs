using System.Linq;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Scaffold
{
    public partial class ScaffoldViewFactoryTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected string viewName;

        public ScaffoldViewFactoryTemplate(CsFileInfo csFileInfo, CsFileInfo viewCsFileInfo)
        {
            this.csFileInfo = csFileInfo;
            viewName = viewCsFileInfo.ObjectName;

            if (!csFileInfo.Usings.Contains(viewCsFileInfo.Namespace))
                csFileInfo.Usings.Add(viewCsFileInfo.Namespace);
        }
    }
}