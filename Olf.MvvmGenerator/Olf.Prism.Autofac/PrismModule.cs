using Autofac;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Regions.Behaviors;
using Microsoft.Practices.ServiceLocation;

namespace Olf.Prism.Autofac
{
    public class PrismModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            ConfigureContainer(builder);

            RegisterComponentContext(builder);
        }

        private static void RegisterComponentContext(ContainerBuilder builder)
        {
            //builder.Register(c => Ioc.Container).As<IComponentContext>().SingleInstance();
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacServiceLocator>().As<IServiceLocator>().SingleInstance();

            //builder.RegisterType<RegionManagerAutoMapHelper>().AsSelf().SingleInstance().PreserveExistingDefaults();
            builder.RegisterType<RegionAdapterMappings>().AsSelf().InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<RegionViewRegistry>().As<IRegionViewRegistry>().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<RegionBehaviorFactory>().As<IRegionBehaviorFactory>().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<TraceLogger>().As<ILoggerFacade>().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<RegionManager>().As<IRegionManager>().ExternallyOwned().SingleInstance().PreserveExistingDefaults();//.InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<SelectorRegionAdapter>().AsSelf().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<ItemsControlRegionAdapter>().AsSelf().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<ContentControlRegionAdapter>().AsSelf().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();

            builder.RegisterType<DelayedRegionCreationBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
            builder.RegisterType<AutoPopulateRegionBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
            builder.RegisterType<BindRegionContextToDependencyObjectBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
            builder.RegisterType<RegionActiveAwareBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
            builder.RegisterType<SyncRegionContextWithHostBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
            builder.RegisterType<RegionManagerRegistrationBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();

            //builder.RegisterType<AutofacServiceLocator>().AsImplementedInterfaces().ExternallyOwned()
            //    .InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<ModuleInitializer>().As<IModuleInitializer>().ExternallyOwned()
                .InstancePerLifetimeScope().PreserveExistingDefaults();
            builder.RegisterType<ModuleManager>().As<IModuleManager>().ExternallyOwned().InstancePerLifetimeScope()
                .PreserveExistingDefaults();

            //builder.RegisterType<ConfigurationModuleEnumerator>().As<IModuleEnumerator>().ExternallyOwned().PreserveExistingDefaults();
            //builder.RegisterType<AutofacContainerAdapter>().As<IContainerFacade>().ExternallyOwned().PreserveExistingDefaults();
            //builder.RegisterType<ModuleLoader>().As<IModuleLoader>().ExternallyOwned().PreserveExistingDefaults();
        }
    }
}