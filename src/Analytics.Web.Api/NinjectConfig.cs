using System;
using System.Configuration;

using Microsoft.AspNet.Identity;
using Ninject;

using Analytics.Data.EntityFramework;
using Analytics.Data.EntityFramework.Repositories;

using Analytics.Web.Api.Identity;

using Analytics.Web.Api.Models;
using Analytics.Web.Api.Models.Repositories;

using Analytics.Web.Api.Providers;
using System.Data.Entity;

namespace Analytics.Web.Api
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var container = new StandardKernel();

            /* Create the bindings */

            // COMMON SECTION
            //--------------------------------------------
            ConfigureDbContext(container);


            // REPOSITORIES SECTION
            //--------------------------------------------
            container.Bind<IExternalLoginRepository>().To<ExternalLoginRepository>();
            container.Bind<IRoleRepository>().To<RoleRepository>();
            container.Bind<IUserRepository>().To<UserRepository>();


            // MODELS SECTION
            //--------------------------------------------
            
            container.Bind<IUserStore<IdentityUser, Guid>>().To<UserStore>();
            container.Bind<IRoleStore<IdentityRole, Guid>>().To<RoleStore>();
            

            // SERVICES SECTION
            //--------------------------------------------
            container.Bind<UserManager<IdentityUser, Guid>>().ToSelf();


            // AUTH SECTION
            //--------------------------------------------
            container.Bind<AuthorizationServerProvider>().ToSelf();

            return container;
        }

        private static void ConfigureDbContext(IKernel container)
        {
            var connectionString =
                ConfigurationManager.ConnectionStrings["local"].ConnectionString;

            var unit = new UnitOfWork(connectionString);
            container.Bind<IUnitOfWork>()
                .To<UnitOfWork>()
                .WithConstructorArgument("nameOrConnectionString", connectionString);

            //container.Bind<UnitOfWork>().ToConstant(unit);
        }
    }
}