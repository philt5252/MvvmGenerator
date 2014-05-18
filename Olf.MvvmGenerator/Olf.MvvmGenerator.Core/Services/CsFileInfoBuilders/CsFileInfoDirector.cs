using Olf.MvvmGenerator.Foundation.Services.CsFileInfoBuilders;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class CsFileInfoDirector
    {
        public void Build(ICsFileInfoBuilder csFileInfoBuilder)
        {
            csFileInfoBuilder.CreateProjectName();
            csFileInfoBuilder.CreateObjectName();
            csFileInfoBuilder.CreateFileName();
            csFileInfoBuilder.CreateFilePath();
            csFileInfoBuilder.CreateNamespace();
            csFileInfoBuilder.CreateBaseClass();
            csFileInfoBuilder.CreateImplementedInterfaces();
            csFileInfoBuilder.CreateProperties();
            csFileInfoBuilder.CreateUsings();
        }
    }
}