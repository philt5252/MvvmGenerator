using Autofac;
using Olf.MvvmGenerator.Core.Controllers;
using Olf.MvvmGenerator.Foundation.Controllers;

namespace Olf.MvvmGenerator.Core.Autofac
{
    public class CoreModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AppController>().As<IAppController>().SingleInstance();
        }
    }
}