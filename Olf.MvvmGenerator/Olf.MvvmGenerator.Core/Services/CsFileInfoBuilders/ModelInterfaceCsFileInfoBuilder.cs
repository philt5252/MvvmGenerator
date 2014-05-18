using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ModelInterfaceCsFileInfoBuilder : CsFileInfoBuilder<ParsedModelCommand>
    {
        public ModelInterfaceCsFileInfoBuilder(ParsedModelCommand parsedCommand, IVisualStudioIde visualStudioIde)
            : base(parsedCommand, visualStudioIde)
        {
        }

        protected override string CreateProjectName(string[] projectNames)
        {
            string projectName = projectNames.FirstOrDefault(p => p.EndsWith(".Foundation"));
            projectName = projectName ?? projectNames.First();

            return projectName;
        }

        protected override string CreateObjectName(ParsedModelCommand parsedCommand)
        {
            return "I" + parsedCommand.ObjectName;
        }

        protected override string CreateFilePath(ParsedModelCommand parsedCommand)
        {
            return string.Format("Models\\{0}", CsFileInfo.FileName);
        }
    }
}