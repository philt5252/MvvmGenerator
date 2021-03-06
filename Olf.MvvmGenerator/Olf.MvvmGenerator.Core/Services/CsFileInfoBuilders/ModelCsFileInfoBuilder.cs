﻿using System.Linq;
using Olf.Common.VisualStudio;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Models;

namespace Olf.MvvmGenerator.Core.Services.CsFileInfoBuilders
{
    public class ModelCsFileInfoBuilder : CsFileInfoBuilder<ParsedCommandWithProperties>
    {
        private readonly CsFileInfo modelInterfaceCsFileInfo;

        public ModelCsFileInfoBuilder(ParsedCommandWithProperties parsedCommand, IVisualStudioIde visualStudioIde,
            CsFileInfo modelInterfaceCsFileInfo)
            : base(parsedCommand, visualStudioIde)
        {
            this.modelInterfaceCsFileInfo = modelInterfaceCsFileInfo;
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
            return string.Format("Models\\{0}", CsFileInfo.FileName);
        }

        public override void CreateUsings()
        {
            base.CreateUsings();

            CsFileInfo.Usings.Add(modelInterfaceCsFileInfo.Namespace);
        }

        public override void CreateImplementedInterfaces()
        {
            CsFileInfo.ImplementedInterfaces.Add(modelInterfaceCsFileInfo.ObjectName);
        }
    }
}