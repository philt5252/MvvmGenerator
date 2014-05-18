using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.ViewModels
{
    public partial class ViewModelTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;

        public ViewModelTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
        }
    }
}