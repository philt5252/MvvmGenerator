using System.Collections.Generic;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Core.Templates.Scaffold;
using Olf.MvvmGenerator.Core.Templates.ViewFactory;
using Olf.MvvmGenerator.Core.Templates.ViewModels;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Foundation.Services.Generators;

namespace Olf.MvvmGenerator.Core.Services.Generators
{
    public class ViewFactoryGenerator : BaseGenerator, IViewFactoryGenerator
    {
        public ViewFactoryGenerator(IVisualStudioIde visualStudioIde) : base(visualStudioIde)
        {
        }

        public void Run(ParsedCommandWithProperties parsedCommand)
        {
            List<FilePreview> filePreviews = new List<FilePreview>();

            ICsFileInfoBuilder viewFactoryInterfaceCsFileInfoBuilder = new ViewFactoryInterfaceCsFileInfoBuilder(parsedCommand, visualStudioIde);
            CsFileInfo viewFactoryInterfaceCsFileInfo = CreateCsFileInfo(viewFactoryInterfaceCsFileInfoBuilder);
            var viewFactoryInterfaceCodeFilePreview = CreateFilePreview(viewFactoryInterfaceCsFileInfo, new ViewFactoryInterfaceTemplate(viewFactoryInterfaceCsFileInfo));

            ICsFileInfoBuilder viewFactoryCsFileInfoBuilder = new ViewFactoryCsFileInfoBuilder(parsedCommand, visualStudioIde, viewFactoryInterfaceCsFileInfo);
            CsFileInfo viewFactoryCsFileInfo = CreateCsFileInfo(viewFactoryCsFileInfoBuilder);
            var viewFactoryCodeFilePreview = CreateFilePreview(viewFactoryCsFileInfo, new ViewFactoryTemplate(viewFactoryCsFileInfo));

            filePreviews.Add(viewFactoryInterfaceCodeFilePreview);
            filePreviews.Add(viewFactoryCodeFilePreview);

            foreach (var filePreview in filePreviews)
            {
                visualStudioIde.AddCodeToProject(filePreview.ProjectName, filePreview.FilePath, filePreview.Content);
            }
        }
    }
}