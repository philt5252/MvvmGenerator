﻿using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ViewModelInterfaceCsFileInfoBuilder : CsFileInfoBuilder<ParsedCommandWithProperties>
    {
        public ViewModelInterfaceCsFileInfoBuilder(ParsedCommandWithProperties parsedCommand, IVisualStudioIde visualStudioIde)
            : base(parsedCommand, visualStudioIde)
        {
        }

        protected override string CreateProjectName(string[] projectNames)
        {
            string projectName = projectNames.FirstOrDefault(p => p.EndsWith(".Foundation"));
            projectName = projectName ?? projectNames.First();

            return projectName;
        }

        protected override string CreateObjectName(ParsedCommandWithProperties parsedCommand)
        {
            return "I" + parsedCommand.ObjectName;
        }

        protected override string CreateFilePath(ParsedCommandWithProperties parsedCommand)
        {
            return string.Format("ViewModels\\{0}", CsFileInfo.FileName);
        }
    }
}