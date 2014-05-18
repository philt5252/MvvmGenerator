﻿using System.Collections.Generic;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Core.Templates.Models;
using Olf.MvvmGenerator.Core.Templates.Scaffold;
using Olf.MvvmGenerator.Core.Templates.ViewModels;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Foundation.Services.Generators;

namespace Olf.MvvmGenerator.Core.Services.Generators
{
    public class ScaffoldGenerator : BaseGenerator, IScaffoldGenerator
    {
        public ScaffoldGenerator(IVisualStudioIde visualStudioIde)
            : base(visualStudioIde)
        {
        }

        public void Run(ParsedCommandWithProperties parsedScaffoldCommand)
        {
            List<FilePreview> filePreviews = new List<FilePreview>();

            ICsFileInfoBuilder modelInterfaceCsFileInfoBuilder = new ModelInterfaceCsFileInfoBuilder(parsedScaffoldCommand, visualStudioIde);
            CsFileInfo modelInterfaceCsFileInfo = CreateCsFileInfo(modelInterfaceCsFileInfoBuilder);
            var modelInterfaceCodeFilePreview = CreateFilePreview(modelInterfaceCsFileInfo, new ModelInterfaceTemplate(modelInterfaceCsFileInfo));

            ICsFileInfoBuilder modelCsFileInfoBuilder = new ModelCsFileInfoBuilder(parsedScaffoldCommand, visualStudioIde, modelInterfaceCsFileInfo);
            CsFileInfo modelCsFileInfo = CreateCsFileInfo(modelCsFileInfoBuilder);
            var modelCodeFilePreview = CreateFilePreview(modelCsFileInfo, new ModelTemplate(modelCsFileInfo));

            ICsFileInfoBuilder modelFactoryInterfaceCsFileInfoBuilder = new ModelFactoryInterfaceCsFileInfoBuilder(parsedScaffoldCommand, visualStudioIde, modelInterfaceCsFileInfo);
            CsFileInfo modelFactoryInterfaceCsFileInfo = CreateCsFileInfo(modelFactoryInterfaceCsFileInfoBuilder);
            var modelFactoryInterfaceCodeFilePreview = CreateFilePreview(modelFactoryInterfaceCsFileInfo, new ModelFactoryInterfaceTemplate(modelFactoryInterfaceCsFileInfo));

            ICsFileInfoBuilder modelFactoryCsFileInfoBuilder = new ModelFactoryCsFileInfoBuilder(parsedScaffoldCommand, visualStudioIde, modelInterfaceCsFileInfo, modelFactoryInterfaceCsFileInfo);
            CsFileInfo modelFactoryCsFileInfo = CreateCsFileInfo(modelFactoryCsFileInfoBuilder);
            var modelFactoryCodeFilePreview = CreateFilePreview(modelFactoryCsFileInfo, new ModelFactoryTemplate(modelFactoryCsFileInfo));

            ICsFileInfoBuilder viewModelInterfaceCsFileInfoBuilder = new ScaffoldViewModelInterfaceCsFileInfoBuilder(parsedScaffoldCommand, visualStudioIde);
            CsFileInfo viewModelInterfaceCsFileInfo = CreateCsFileInfo(viewModelInterfaceCsFileInfoBuilder);
            var viewModelInterfaceCodeFilePreview = CreateFilePreview(viewModelInterfaceCsFileInfo, new ScaffoldViewModelInterfaceTemplate(viewModelInterfaceCsFileInfo));

            ICsFileInfoBuilder viewModelCsFileInfoBuilder = new ScaffoldViewModelCsFileInfoBuilder(parsedScaffoldCommand, visualStudioIde, viewModelInterfaceCsFileInfo);
            CsFileInfo viewModelCsFileInfo = CreateCsFileInfo(viewModelCsFileInfoBuilder);
            var viewModelCodeFilePreview = CreateFilePreview(viewModelCsFileInfo, new ScaffoldViewModelTemplate(viewModelCsFileInfo, modelInterfaceCsFileInfo));

            ICsFileInfoBuilder viewModelFactoryInterfaceCsFileInfoBuilder = new ScaffoldViewModelFactoryInterfaceCsFileInfoBuilder(parsedScaffoldCommand, visualStudioIde, viewModelInterfaceCsFileInfo);
            CsFileInfo viewModelFactoryInterfaceCsFileInfo = CreateCsFileInfo(viewModelFactoryInterfaceCsFileInfoBuilder);
            var viewModelFactoryInterfaceCodeFilePreview = CreateFilePreview(viewModelFactoryInterfaceCsFileInfo, new ScaffoldViewModelFactoryInterfaceTemplate(viewModelFactoryInterfaceCsFileInfo, modelInterfaceCsFileInfo));

            ICsFileInfoBuilder viewModelFactoryCsFileInfoBuilder = new ScaffoldViewModelFactoryCsFileInfoBuilder(parsedScaffoldCommand, visualStudioIde, viewModelInterfaceCsFileInfo, viewModelFactoryInterfaceCsFileInfo);
            CsFileInfo viewModelFactoryCsFileInfo = CreateCsFileInfo(viewModelFactoryCsFileInfoBuilder);
            var viewModelFactoryCodeFilePreview = CreateFilePreview(viewModelFactoryCsFileInfo, new ScaffoldViewModelFactoryTemplate(viewModelFactoryCsFileInfo, modelInterfaceCsFileInfo));

            filePreviews.Add(modelInterfaceCodeFilePreview);
            filePreviews.Add(modelCodeFilePreview);
            filePreviews.Add(modelFactoryInterfaceCodeFilePreview);
            filePreviews.Add(modelFactoryCodeFilePreview);

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