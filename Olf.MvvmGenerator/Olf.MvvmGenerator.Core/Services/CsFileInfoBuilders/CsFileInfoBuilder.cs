using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;
using Olf.MvvmGenerator.Foundation.Services.CsFileInfoBuilders;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public abstract class CsFileInfoBuilder<T> : ICsFileInfoBuilder where T : ParsedCommandWithProperties
    {
        protected CsFileInfo CsFileInfo;
        protected string FileExtension;
        private readonly T parsedCommand;
        private readonly IVisualStudioIde visualStudioIde;
        private readonly string[] projectNames;

        protected CsFileInfoBuilder(T parsedCommand, IVisualStudioIde visualStudioIde)
        {
            CsFileInfo = new CsFileInfo();

            this.parsedCommand = parsedCommand;
            this.visualStudioIde = visualStudioIde;
            projectNames = visualStudioIde.GetProjectNames();

            FileExtension = ".cs";
        }

        public CsFileInfo GetResult()
        {
            return CsFileInfo;
        }

        public void CreateProjectName()
        {
            CsFileInfo.ProjectName = CreateProjectName(projectNames);
        }

        public virtual void CreateNamespace()
        {
            string projectNamespace = visualStudioIde.GetDefaultNamespaceForProject(CsFileInfo.ProjectName);

            string dottedPath = CsFileInfo.FilePath.Replace(".", "").Replace('\\', '.');

            CsFileInfo.Namespace = projectNamespace + "." + dottedPath.Substring(0, dottedPath.LastIndexOf('.'));
        }

        public void CreateObjectName()
        {
            CsFileInfo.ObjectName = CreateObjectName(parsedCommand);
        }

        public virtual void CreateBaseClass()
        {
            CsFileInfo.BaseClass = null;
        }

        public virtual void CreateImplementedInterfaces()
        {

        }

        public void CreateFileName()
        {
            CsFileInfo.FileName = CreateFileName(parsedCommand);
        }

        public void CreateFilePath()
        {
            CsFileInfo.FilePath = CreateFilePath(parsedCommand);
        }

        public virtual void CreateProperties()
        {
            CsFileInfo.Properties.AddRange(parsedCommand.Properties);
        }

        public virtual void CreateUsings()
        {
            CsFileInfo.Usings.AddRange(parsedCommand.Properties.Select(p => p.PropertyType.Namespace).Distinct()); ;
        }

        protected virtual string CreateFileName(T parsedCommand)
        {
            return CsFileInfo.ObjectName + FileExtension;
        }

        protected virtual string CreateObjectName(T parsedCommand)
        {
            return parsedCommand.ObjectName;
        }

        protected abstract string CreateProjectName(string[] projectNames);
        protected abstract string CreateFilePath(T parsedCommand);
    }
}