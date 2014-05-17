using Autofac;
using Olf.MvvmGenerator.Core.Views.Factories;
using Olf.MvvmGenerator.Foundation.Views.Factories;

namespace Olf.MvvmGenerator.Core.Views.Autofac
{
    public class ViewsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<GenerateCommandWindow>().AsSelf();

            builder.RegisterType<GenerateCommandWindowFactory>().As<IGenerateCommandWindowFactory>().SingleInstance();
        }
    }
}