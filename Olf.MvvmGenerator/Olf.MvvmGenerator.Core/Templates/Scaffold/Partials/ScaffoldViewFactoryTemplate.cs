using System.Linq;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Scaffold
{
    public partial class ScaffoldViewFactoryTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected string viewName;

        public ScaffoldViewFactoryTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
            viewName = csFileInfo.ObjectName.Replace("Factory", "");
        }
    }
}