using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ScaffoldViewXamlFileInfoBuilder : CsFileInfoBuilder<ParsedCommandWithProperties>
    {
        public ScaffoldViewXamlFileInfoBuilder(ParsedCommandWithProperties parsedCommand, IVisualStudioIde visualStudioIde)
            : base(parsedCommand, visualStudioIde)
        {
            FileExtension = ".xaml";
        }

        protected override string CreateProjectName(string[] projectNames)
        {
            string projectName = projectNames.FirstOrDefault(p => p.EndsWith(".Core.Views"));
            projectName = projectName ?? projectNames.First();

            return projectName;
        }

        protected override string CreateObjectName(ParsedCommandWithProperties parsedCommand)
        {
            return parsedCommand.ObjectName + "View";
        }

        protected override string CreateFilePath(ParsedCommandWithProperties parsedCommand)
        {
            return string.Format("{0}", CsFileInfo.FileName);
        }
    }
}