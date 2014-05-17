using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.Practices.ServiceLocation;

namespace Olf.Prism.Autofac
{
    public sealed class AutofacServiceLocator : ServiceLocatorImplBase
    {
        readonly IComponentContext container;

        public AutofacServiceLocator(IComponentContext container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.container = container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            object retObj = key != null ? container.ResolveNamed(key, serviceType) : container.Resolve(serviceType);

            return retObj;
        }

        public override IEnumerable<TService> GetAllInstances<TService>()
        {
            return GetAllInstances(typeof(TService)).Cast<TService>();
        }

        public override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return DoGetAllInstances(serviceType);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            var enumerableType = typeof(IEnumerable<>).MakeGenericType(serviceType);

            object instance = container.Resolve(enumerableType);

            IEnumerable<object> enumerableInstance = ((IEnumerable)instance).Cast<object>();

            var instances = enumerableInstance as List<object> ?? enumerableInstance.ToList();

            return instances;
        }
    }
}