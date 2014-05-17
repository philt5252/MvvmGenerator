using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Microsoft.Practices.ServiceLocation;
using Olf.MvvmGenerator.Core.Autofac;
using Olf.MvvmGenerator.Core.Views.Autofac;
using Olf.MvvmGenerator.Foundation.Controllers;
using Olf.Prism.Autofac;

namespace Olf.MvvmGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<ViewsModule>();
            builder.RegisterModule<PrismModule>();

            IContainer container = builder.Build();

            IServiceLocator serviceLocator = container.Resolve<IServiceLocator>();

            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            IAppController appController;

            using (ILifetimeScope scope = container.BeginLifetimeScope())
            {
                appController = scope.Resolve<IAppController>();
            }

            appController.Home();
        }
    }
}
