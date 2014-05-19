using System.Linq;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Scaffold
{
    public partial class ScaffoldViewXamlTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;

        public ScaffoldViewXamlTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
        }
    }
}