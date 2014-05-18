using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Models
{
    public partial class ModelInterfaceTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;

        public ModelInterfaceTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
        }
    }

    
}