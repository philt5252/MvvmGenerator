using System.Collections.Generic;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Core.Templates;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Foundation.Services.Generators;

namespace Olf.MvvmGenerator.Core.Services.Generators
{
    public class ViewModelGenerator : BaseGenerator, IViewModelGenerator
    {
        public ViewModelGenerator(IVisualStudioIde visualStudioIde)
            : base(visualStudioIde)
        {
        }

        public void Run(ParsedViewModelCommand parsedViewModelCommand)
        {
            List<FilePreview> filePreviews = new List<FilePreview>();

            ICsFileInfoBuilder viewModelInterfaceCsFileInfoBuilder = new ViewModelInterfaceCsFileInfoBuilder(parsedViewModelCommand, visualStudioIde);
            CsFileInfo viewModelInterfaceCsFileInfo = CreateCsFileInfo(viewModelInterfaceCsFileInfoBuilder);
            var viewModelInterfaceCodeFilePreview = CreateFilePreview(viewModelInterfaceCsFileInfo, new ModelInterfaceTemplate(viewModelInterfaceCsFileInfo));

            ICsFileInfoBuilder viewModelCsFileInfoBuilder = new ViewModelCsFileInfoBuilder(parsedViewModelCommand, visualStudioIde, viewModelInterfaceCsFileInfo);
            CsFileInfo viewModelCsFileInfo = CreateCsFileInfo(viewModelCsFileInfoBuilder);
            var viewModelCodeFilePreview = CreateFilePreview(viewModelCsFileInfo, new ModelTemplate(viewModelCsFileInfo));

            ICsFileInfoBuilder viewModelFactoryInterfaceCsFileInfoBuilder = new ViewModelFactoryInterfaceCsFileInfoBuilder(parsedViewModelCommand, visualStudioIde, viewModelInterfaceCsFileInfo);
            CsFileInfo viewModelFactoryInterfaceCsFileInfo = CreateCsFileInfo(viewModelFactoryInterfaceCsFileInfoBuilder);
            var viewModelFactoryInterfaceCodeFilePreview = CreateFilePreview(viewModelFactoryInterfaceCsFileInfo, new ModelFactoryInterfaceTemplate(viewModelFactoryInterfaceCsFileInfo));

            ICsFileInfoBuilder viewModelFactoryCsFileInfoBuilder = new ViewModelFactoryCsFileInfoBuilder(parsedViewModelCommand, visualStudioIde, viewModelInterfaceCsFileInfo, viewModelFactoryInterfaceCsFileInfo);
            CsFileInfo viewModelFactoryCsFileInfo = CreateCsFileInfo(viewModelFactoryCsFileInfoBuilder);
            var viewModelFactoryCodeFilePreview = CreateFilePreview(viewModelFactoryCsFileInfo, new ModelFactoryTemplate(viewModelFactoryCsFileInfo));

            filePreviews.Add(viewModelInterfaceCodeFilePreview);
            filePreviews.Add(viewModelCodeFilePreview);
            filePreviews.Add(viewModelFactoryInterfaceCodeFilePreview);
            filePreviews.Add(viewModelFactoryCodeFilePreview);

            foreach (var filePreview in filePreviews)
            {
                visualStudioIde.AddCodeToProject(filePreview.ProjectName, filePreview.FilePath, filePreview.Content);
            }
        }
    }
}