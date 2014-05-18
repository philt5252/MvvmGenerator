using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ModelFactoryCsFileInfoBuilder : CsFileInfoBuilder<ParsedModelCommand>
    {
        private readonly CsFileInfo modelInterfaceCsFileInfo;
        private readonly CsFileInfo modelFactoryInterfaceCsFileInfo;

        public ModelFactoryCsFileInfoBuilder(ParsedModelCommand parsedCommand, IVisualStudioIde visualStudioIde, 
            CsFileInfo modelInterfaceCsFileInfo, CsFileInfo modelFactoryInterfaceCsFileInfo) 
            : base(parsedCommand, visualStudioIde)
        {
            this.modelInterfaceCsFileInfo = modelInterfaceCsFileInfo;
            this.modelFactoryInterfaceCsFileInfo = modelFactoryInterfaceCsFileInfo;
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

        protected override string CreateObjectName(ParsedModelCommand parsedCommand)
        {
            return parsedCommand.ObjectName + "Factory";
        }

        protected override string CreateFilePath(ParsedModelCommand parsedCommand)
        {
            return string.Format("Factories\\Models\\{0}", CsFileInfo.FileName);
        }

        public override void CreateUsings()
        {
            base.CreateUsings();

            CsFileInfo.Usings.Add(modelInterfaceCsFileInfo.Namespace);
            CsFileInfo.Usings.Add(modelFactoryInterfaceCsFileInfo.Namespace);

            CsFileInfo.Usings = CsFileInfo.Usings.Distinct().ToList();
        }

        public override void CreateBaseClass()
        {
            CsFileInfo.BaseClass = modelFactoryInterfaceCsFileInfo.ObjectName;
        }
    }
}