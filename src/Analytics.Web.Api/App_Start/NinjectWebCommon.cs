[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Analytics.Web.Api.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Analytics.Web.Api.NinjectWebCommon), "Stop")]

namespace Analytics.Web.Api
{
    using System;
    using System.Web;
    using System.Web.Http;
    
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using WebActivatorEx;

    using Analytics.Web.Common;


   /*
    * Make sure a DI container is created during 
    * application start-up and remains in memory
    * until the application shuts down. (You can think 
    * of the container as the object that contains the dependencies.)
    * 
    */

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            IKernel container = null;
            Bootstrapper.Initialize(() =>
            {
                container = CreateKernel();
                return container;
            });


            var resolver = new NinjectDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var containerConfigurator = new NinjectConfigurator();
            containerConfigurator.Configure(kernel);
        }
    }
}

/*
 * It's important to note that the registration of our dependency resolver with WEB API
 * and configuration of container bindings by the NinjectConfigurator.Configure method
 * are both called (the former directly, the letter indirectly) from the Start method, 
 * which is called during application start-up. In this way, all of this setup is completed
 * before the application accepts and processes anu HTTP requests, and thus before any of the
 * controllers - which rely on dependencies being injected into them - are ever created.
 * 
 */