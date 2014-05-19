using System.Linq;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Scaffold
{
    public partial class ScaffoldListViewXamlTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected string selectedItemsName;
        protected string itemsName;

        public ScaffoldListViewXamlTemplate(CsFileInfo csFileInfo, CsFileInfo modelCsFileInfo)
        {
            this.csFileInfo = csFileInfo;

            itemsName = modelCsFileInfo.ObjectName + "List";
            selectedItemsName = "Selected" + modelCsFileInfo.ObjectName;
        }
    }
}