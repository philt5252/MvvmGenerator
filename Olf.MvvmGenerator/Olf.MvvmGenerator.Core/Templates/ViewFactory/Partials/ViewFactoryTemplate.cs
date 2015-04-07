using System.Linq;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.ViewFactory
{
    public partial class ViewFactoryTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected string viewName;

        public ViewFactoryTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
            viewName = csFileInfo.ObjectName.Substring(0, csFileInfo.ObjectName.LastIndexOf("Factory"));

            //if (!csFileInfo.Usings.Contains(viewCsFileInfo.Namespace))
            //    csFileInfo.Usings.Add(viewCsFileInfo.Namespace);
        }
    }
}