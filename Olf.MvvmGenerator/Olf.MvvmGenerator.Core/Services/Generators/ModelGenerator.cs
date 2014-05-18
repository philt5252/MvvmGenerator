using System.Collections.Generic;
using System.Windows.Media;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Core.Templates;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Foundation.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Services.Generators
{
    public class ModelGenerator : BaseGenerator, IModelGenerator
    {
        public ModelGenerator(IVisualStudioIde visualStudioIde)
            : base(visualStudioIde)
        {
            
        }

        public void Run(ParsedModelCommand parsedModelCommand)
        {
            List<FilePreview> filePreviews = new List<FilePreview>();

            ICsFileInfoBuilder modelInterfaceCsFileInfoBuilder = new ModelInterfaceCsFileInfoBuilder(parsedModelCommand, visualStudioIde);
            CsFileInfo modelInterfaceCsFileInfo = CreateCsFileInfo(modelInterfaceCsFileInfoBuilder);
            var modelInterfaceCodeFilePreview = CreateFilePreview(modelInterfaceCsFileInfo, new ModelInterfaceTemplate(modelInterfaceCsFileInfo));

            ICsFileInfoBuilder modelCsFileInfoBuilder = new ModelCsFileInfoBuilder(parsedModelCommand, visualStudioIde, modelInterfaceCsFileInfo);
            CsFileInfo modelCsFileInfo = CreateCsFileInfo(modelCsFileInfoBuilder);
            var modelCodeFilePreview = CreateFilePreview(modelCsFileInfo, new ModelTemplate(modelCsFileInfo));

            ICsFileInfoBuilder modelFactoryInterfaceCsFileInfoBuilder = new ModelFactoryInterfaceCsFileInfoBuilder(parsedModelCommand, visualStudioIde, modelInterfaceCsFileInfo);
            CsFileInfo modelFactoryInterfaceCsFileInfo = CreateCsFileInfo(modelFactoryInterfaceCsFileInfoBuilder);
            var modelFactoryInterfaceCodeFilePreview = CreateFilePreview(modelFactoryInterfaceCsFileInfo, new ModelFactoryInterfaceTemplate(modelFactoryInterfaceCsFileInfo));

            ICsFileInfoBuilder modelFactoryCsFileInfoBuilder = new ModelFactoryCsFileInfoBuilder(parsedModelCommand, visualStudioIde, modelInterfaceCsFileInfo, modelFactoryInterfaceCsFileInfo);
            CsFileInfo modelFactoryCsFileInfo = CreateCsFileInfo(modelFactoryCsFileInfoBuilder);
            var modelFactoryCodeFilePreview = CreateFilePreview(modelFactoryCsFileInfo, new ModelFactoryTemplate(modelFactoryCsFileInfo));

            filePreviews.Add(modelInterfaceCodeFilePreview);
            filePreviews.Add(modelCodeFilePreview);
            filePreviews.Add(modelFactoryInterfaceCodeFilePreview);
            filePreviews.Add(modelFactoryCodeFilePreview);

            foreach (var filePreview in filePreviews)
            {
                visualStudioIde.AddCodeToProject(filePreview.ProjectName, filePreview.FilePath, filePreview.Content);
            }
        }

    }
}