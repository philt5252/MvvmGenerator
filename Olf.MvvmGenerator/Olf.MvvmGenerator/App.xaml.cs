using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using EnvDTE80;
using Microsoft.Practices.ServiceLocation;
using Olf.Common.VisualStudio;
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
        private DTE2 _applicationObject;

        public App()
        {
            
        }

        public App(object applicationObject)
        {
            _applicationObject = applicationObject as DTE2;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<ViewsModule>();
            builder.RegisterModule<PrismModule>();

            if (_applicationObject != null)
            {
                VisualStudioIde visualStudioIde = new VisualStudioIde(_applicationObject);

                builder.RegisterInstance(visualStudioIde).As<IVisualStudioIde>().ExternallyOwned().SingleInstance();
            }
            else
            {
                Dummy.Common.VisualStudio.VisualStudioIde visualStudioIde = new Dummy.Common.VisualStudio.VisualStudioIde();

                builder.RegisterInstance(visualStudioIde).As<IVisualStudioIde>().ExternallyOwned().SingleInstance();
            }

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
