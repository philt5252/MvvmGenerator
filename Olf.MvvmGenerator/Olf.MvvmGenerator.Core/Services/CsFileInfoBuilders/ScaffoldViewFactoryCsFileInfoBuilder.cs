using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ScaffoldViewFactoryCsFileInfoBuilder : CsFileInfoBuilder<ParsedCommandWithProperties>
    {
          private readonly CsFileInfo viewFactoryInterfaceCsFileInfo;

          public ScaffoldViewFactoryCsFileInfoBuilder(ParsedCommandWithProperties parsedCommand, IVisualStudioIde visualStudioIde,
            CsFileInfo viewFactoryInterfaceCsFileInfo) 
            : base(parsedCommand, visualStudioIde)
        {
            this.viewFactoryInterfaceCsFileInfo = viewFactoryInterfaceCsFileInfo;
        }

        protected override string CreateProjectName(string[] projectNames)
        {
            string projectName = projectNames.FirstOrDefault(p => p.EndsWith(".Core.Views"));
            projectName = projectName ?? projectNames.First();

            return projectName;
        }

        public override void CreateProperties()
        {
            //base.CreateProperties();
        }

        protected override string CreateObjectName(ParsedCommandWithProperties parsedCommand)
        {
            return parsedCommand.ObjectName + "ViewFactory";
        }

        protected override string CreateFilePath(ParsedCommandWithProperties parsedCommand)
        {
            return string.Format("Factories\\{0}", CsFileInfo.FileName);
        }

        public override void CreateUsings()
        {
            base.CreateUsings();

            CsFileInfo.Usings.Add(viewFactoryInterfaceCsFileInfo.Namespace);

            CsFileInfo.Usings = CsFileInfo.Usings.Distinct().ToList();
        }

        public override void CreateBaseClass()
        {
            CsFileInfo.BaseClass = viewFactoryInterfaceCsFileInfo.ObjectName;
        }
    }
}