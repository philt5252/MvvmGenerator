﻿using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ViewModelCsFileInfoBuilder : CsFileInfoBuilder<ParsedCommandWithProperties>
    {

        private readonly CsFileInfo viewModelInterfaceCsFileInfo;

        public ViewModelCsFileInfoBuilder(ParsedCommandWithProperties parsedCommand, IVisualStudioIde visualStudioIde,
            CsFileInfo viewModelInterfaceCsFileInfo)
            : base(parsedCommand, visualStudioIde)
        {
            this.viewModelInterfaceCsFileInfo = viewModelInterfaceCsFileInfo;
        }

        protected override string CreateProjectName(string[] projectNames)
        {
            string projectName = projectNames.FirstOrDefault(p => p.EndsWith(".Core"));
            projectName = projectName ?? projectNames.First();

            return projectName;
        }

        protected override string CreateObjectName(ParsedCommandWithProperties parsedCommand)
        {
            return parsedCommand.ObjectName;
        }

        protected override string CreateFilePath(ParsedCommandWithProperties parsedCommand)
        {
            return string.Format("ViewModels\\{0}", CsFileInfo.FileName);
        }

        public override void CreateUsings()
        {
            base.CreateUsings();

            CsFileInfo.Usings.Add(viewModelInterfaceCsFileInfo.Namespace);
        }

        public override void CreateImplementedInterfaces()
        {
            CsFileInfo.ImplementedInterfaces.Add(viewModelInterfaceCsFileInfo.ObjectName);
        } 
    }
}