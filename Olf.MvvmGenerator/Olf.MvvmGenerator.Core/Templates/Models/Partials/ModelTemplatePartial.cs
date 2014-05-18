using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.Models
{
    public partial class ModelTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;

        public ModelTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
        }
    }
}