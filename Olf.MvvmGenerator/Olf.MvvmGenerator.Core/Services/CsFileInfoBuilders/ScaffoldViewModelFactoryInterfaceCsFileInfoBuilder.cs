using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ScaffoldViewModelFactoryInterfaceCsFileInfoBuilder : CsFileInfoBuilder<ParsedCommandWithProperties>
    {
        private readonly CsFileInfo viewModelInterfaceCsFileInfo;

        public ScaffoldViewModelFactoryInterfaceCsFileInfoBuilder(ParsedCommandWithProperties parsedCommand, IVisualStudioIde visualStudioIde,
            CsFileInfo viewModelInterfaceCsFileInfo) 
            : base(parsedCommand, visualStudioIde)
        {
            this.viewModelInterfaceCsFileInfo = viewModelInterfaceCsFileInfo;
        }

        protected override string CreateProjectName(string[] projectNames)
        {
            string projectName = projectNames.FirstOrDefault(p => p.EndsWith(".Foundation"));
            projectName = projectName ?? projectNames.First();

            return projectName;
        }

        public override void CreateProperties()
        {
            //base.CreateProperties();
        }

        protected override string CreateObjectName(ParsedCommandWithProperties parsedCommand)
        {
            return "I" + parsedCommand.ObjectName + "ViewModelFactory";
        }

        protected override string CreateFilePath(ParsedCommandWithProperties parsedCommand)
        {
            return string.Format("Factories\\ViewModels\\{0}", CsFileInfo.FileName);
        }

        public override void CreateUsings()
        {
            base.CreateUsings();

            CsFileInfo.Usings.Add(viewModelInterfaceCsFileInfo.Namespace);
        }
    }
}