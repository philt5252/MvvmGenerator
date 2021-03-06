﻿using Autofac;
using Olf.MvvmGenerator.Core.Controllers;
using Olf.MvvmGenerator.Core.Factories.ViewModels;
using Olf.MvvmGenerator.Core.Services.Generators;
using Olf.MvvmGenerator.Core.Services.Parsers;
using Olf.MvvmGenerator.Core.Services.Runners;
using Olf.MvvmGenerator.Core.ViewModels;
using Olf.MvvmGenerator.Foundation.Controllers;
using Olf.MvvmGenerator.Foundation.Factories.ViewModels;
using Olf.MvvmGenerator.Foundation.Services.Generators;
using Olf.MvvmGenerator.Foundation.Services.Parsers;
using Olf.MvvmGenerator.Foundation.Services.Runners;
using Olf.MvvmGenerator.Foundation.ViewModels;

namespace Olf.MvvmGenerator.Core.Autofac
{
    public class CoreModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AppController>().As<IAppController>().SingleInstance();

            builder.RegisterType<GenerateCommandViewModel>().As<IGenerateCommandViewModel>();

            builder.RegisterType<GenerateCommandViewModelFactory>().As<IGenerateCommandViewModelFactory>().SingleInstance();

            builder.RegisterType<CommandRunnerManager>().As<ICommandRunnerManager>().SingleInstance();

            builder.RegisterType<ModelCommandRunner>().As<ICommandRunner>().SingleInstance();
            builder.RegisterType<ViewModelCommandRunner>().As<ICommandRunner>().SingleInstance();
            builder.RegisterType<ScaffoldCommandRunner>().As<ICommandRunner>().SingleInstance();
            builder.RegisterType<ViewFactoryCommandRunner>().As<ICommandRunner>().SingleInstance();

            builder.RegisterType<ModelGenerator>().As<IModelGenerator>().SingleInstance();
            builder.RegisterType<ViewModelGenerator>().As<IViewModelGenerator>().SingleInstance();
            builder.RegisterType<ScaffoldGenerator>().As<IScaffoldGenerator>().SingleInstance();
            builder.RegisterType<ViewFactoryGenerator>().As<IViewFactoryGenerator>().SingleInstance();

            builder.RegisterType<ModelCommandParser>().As<IModelCommandParser>().SingleInstance();
            builder.RegisterType<ViewModelCommandParser>().As<IViewModelCommandParser>().SingleInstance();
            builder.RegisterType<ScaffoldCommandParser>().As<IScaffoldCommandParser>().SingleInstance();
            builder.RegisterType<ViewFactoryCommandParser>().As<IViewFactoryCommandParser>().SingleInstance();
        }
    }
}