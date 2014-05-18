using Olf.MvvmGenerator.Core.Services.Generators;

namespace Olf.MvvmGenerator.Foundation.Services.CsFileInfoBuilders
{
    public interface ICsFileInfoBuilder
    {
        CsFileInfo GetResult();

        void CreateProjectName();
        void CreateNamespace();
        void CreateObjectName();
        void CreateFileName();
        void CreateFilePath();
        void CreateProperties();
        void CreateUsings();
        void CreateBaseClass();
        void CreateImplementedInterfaces();
    }
}