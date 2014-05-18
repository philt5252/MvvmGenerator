using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ViewModelFactoryCsFileInfoBuilder : CsFileInfoBuilder<ParsedViewModelCommand>
    {
          private readonly CsFileInfo viewModelInterfaceCsFileInfo;
          private readonly CsFileInfo viewModelFactoryInterfaceCsFileInfo;

        public ViewModelFactoryCsFileInfoBuilder(ParsedViewModelCommand parsedCommand, IVisualStudioIde visualStudioIde,
            CsFileInfo viewModelInterfaceCsFileInfo, CsFileInfo viewModelFactoryInterfaceCsFileInfo) 
            : base(parsedCommand, visualStudioIde)
        {
            this.viewModelInterfaceCsFileInfo = viewModelInterfaceCsFileInfo;
            this.viewModelFactoryInterfaceCsFileInfo = viewModelFactoryInterfaceCsFileInfo;
        }

        protected override string CreateProjectName(string[] projectNames)
        {
            string projectName = projectNames.FirstOrDefault(p => p.EndsWith(".Core"));
            projectName = projectName ?? projectNames.First();

            return projectName;
        }

        public override void CreateProperties()
        {
            //base.CreateProperties();
        }

        protected override string CreateObjectName(ParsedViewModelCommand parsedCommand)
        {
            return parsedCommand.ObjectName + "Factory";
        }

        protected override string CreateFilePath(ParsedViewModelCommand parsedCommand)
        {
            return string.Format("Factories\\ViewModels\\{0}", CsFileInfo.FileName);
        }

        public override void CreateUsings()
        {
            base.CreateUsings();

            CsFileInfo.Usings.Add(viewModelInterfaceCsFileInfo.Namespace);
            CsFileInfo.Usings.Add(viewModelFactoryInterfaceCsFileInfo.Namespace);

            CsFileInfo.Usings = CsFileInfo.Usings.Distinct().ToList();
        }

        public override void CreateBaseClass()
        {
            CsFileInfo.BaseClass = viewModelFactoryInterfaceCsFileInfo.ObjectName;
        }
    }
}