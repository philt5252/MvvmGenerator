using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.ViewModels
{
    public partial class ViewModelInterfaceTemplate : IFileTemplate
    {
         protected readonly CsFileInfo csFileInfo;

         public ViewModelInterfaceTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
        }
    }
}