using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace WebApiServiceEndpoints.DI
{
    public class UnityIoC : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityIoC(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }


        public object GetService(Type serviceType)
        {
            if (!container.IsRegistered(serviceType))
            {

                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return null;
                }
            }
            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityIoC(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}