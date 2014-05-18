using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.CsFileInfoBuilders;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Services.Generators
{
    public class BaseGenerator
    {
        protected readonly IVisualStudioIde visualStudioIde;
        protected CsFileInfoDirector csFileInfoDirector = new CsFileInfoDirector();

        public BaseGenerator(IVisualStudioIde visualStudioIde)
        {
            this.visualStudioIde = visualStudioIde;
        }

        protected virtual CsFileInfo CreateCsFileInfo(ICsFileInfoBuilder csFileInfoBuilder)
        {
            csFileInfoDirector.Build(csFileInfoBuilder);
            return csFileInfoBuilder.GetResult();
        }

        protected virtual FilePreview CreateFilePreview(CsFileInfo csFileInfo, IFileTemplate fileTemplate)
        {
            string transformText = fileTemplate.TransformText();

            FilePreview codeFilePreview = new FilePreview
            {
                FilePath = csFileInfo.FilePath,
                FileName = csFileInfo.FileName,
                Content = transformText,
                ProjectName = csFileInfo.ProjectName
            };

            return codeFilePreview;
        } 
    }
}