using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ScaffoldViewFactoryInterfaceCsFileInfoBuilder : CsFileInfoBuilder<ParsedCommandWithProperties>
    {
        public ScaffoldViewFactoryInterfaceCsFileInfoBuilder(ParsedCommandWithProperties parsedCommand, IVisualStudioIde visualStudioIde) 
            : base(parsedCommand, visualStudioIde)
        {
        }

        protected override string CreateProjectName(string[] projectNames)
        {
            string projectName = projectNames.FirstOrDefault(p => p.EndsWith(".Foundation.Views"));
            projectName = projectName ?? projectNames.First();

            return projectName;
        }

        public override void CreateProperties()
        {
            //base.CreateProperties();
        }

        protected override string CreateObjectName(ParsedCommandWithProperties parsedCommand)
        {
            return "I" + parsedCommand.ObjectName + "ViewFactory";
        }

        protected override string CreateFilePath(ParsedCommandWithProperties parsedCommand)
        {
            return string.Format("Factories\\{0}", CsFileInfo.FileName);
        }

        public override void CreateUsings()
        {
            base.CreateUsings();

            //CsFileInfo.Usings.Add(viewFactoryInterfaceCsFileInfo.Namespace);
        }
    }
}