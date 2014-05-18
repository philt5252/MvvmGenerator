using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ModelFactoryInterfaceCsFileInfoBuilder : CsFileInfoBuilder<ParsedModelCommand>
    {
        private readonly CsFileInfo modelInterfaceCsFileInfo;

        public ModelFactoryInterfaceCsFileInfoBuilder(ParsedModelCommand parsedCommand, IVisualStudioIde visualStudioIde, 
            CsFileInfo modelInterfaceCsFileInfo) 
            : base(parsedCommand, visualStudioIde)
        {
            this.modelInterfaceCsFileInfo = modelInterfaceCsFileInfo;
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

        protected override string CreateObjectName(ParsedModelCommand parsedCommand)
        {
            return "I" + parsedCommand.ObjectName + "Factory";
        }

        protected override string CreateFilePath(ParsedModelCommand parsedCommand)
        {
            return string.Format("Factories\\Models\\{0}", CsFileInfo.FileName);
        }

        public override void CreateUsings()
        {
            base.CreateUsings();

            CsFileInfo.Usings.Add(modelInterfaceCsFileInfo.Namespace);
        }
    }
}