﻿using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Foundation.Templates;

namespace Olf.MvvmGenerator.Core.Templates.ViewModels
{
    public partial class ViewModelFactoryTemplate : IFileTemplate
    {
        protected readonly CsFileInfo csFileInfo;
        protected readonly string interfaceObjectName;

        public ViewModelFactoryTemplate(CsFileInfo csFileInfo)
        {
            this.csFileInfo = csFileInfo;
            interfaceObjectName = "I" + csFileInfo.ObjectName.Replace("Factory", "");
        }
    }
}