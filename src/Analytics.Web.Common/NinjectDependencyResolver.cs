using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

using Ninject;

namespace Analytics.Web.Common
{
    /// <summary>
    ///     An <see cref="IDependencyResolver" /> implemented using the Ninject DI container.
    /// </summary>
    public sealed class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _container;
        public IKernel Container
        {
            get { return _container; }
        }

        public NinjectDependencyResolver(IKernel container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        // delegate to the Ninject container to get object instances for the requested service types
        public object GetService(Type serviceType)
        {
          /* 
           * prevent Ninject from blowing up if it is asked for a dependency that it can't provide 
           * because the dependency - or one of its dependencies - was never registered
           * we simply want to return null if we haven't explicitly registered a given type.
           * 
           */
            return _container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
