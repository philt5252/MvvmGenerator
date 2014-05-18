using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ViewModelFactoryInterfaceCsFileInfoBuilder : CsFileInfoBuilder<ParsedViewModelCommand>
    {
        private readonly CsFileInfo viewModelInterfaceCsFileInfo;

         public ViewModelFactoryInterfaceCsFileInfoBuilder(ParsedViewModelCommand parsedCommand, IVisualStudioIde visualStudioIde,
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

        protected override string CreateObjectName(ParsedViewModelCommand parsedCommand)
        {
            return "I" + parsedCommand.ObjectName + "Factory";
        }

        protected override string CreateFilePath(ParsedViewModelCommand parsedCommand)
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