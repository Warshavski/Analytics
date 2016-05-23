using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

using Ninject;
using Ninject.Web.Common;


using Analytics.Common.TypeMapping;

using Analytics.Data.QueryProcessors;

using Analytics.Data.SqlServer;
using Analytics.Data.SqlServer.QueryProcessors;

using Analytics.Web.Api.AutoMappingConfiguration;
using Analytics.Web.Api.InquiryProcessing;

namespace Analytics.Web.Api
{
   /*
    * This is where we bind or relate interfaces 
    * to concrete implementations so that the
    * dependencies can be resolved at run time.
    * For example, if a class requires an IDateTime object, 
    * the bindings tell the container to provide a DateTimeAdapter object.
    * 
    */


    /// <summary>
    ///     Class used to set up the Ninject DI container.
    /// </summary>
    public sealed class NinjectConfigurator
    {
        /// <summary>
        ///     Entry method used by caller to configure the given
        ///     container with all of this application's
        ///     dependencies.
        /// </summary>
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            ConfigureEntityFramework(container);
            ConfigureAutoMapper(container);

            container.Bind<IUserByIdQueryProcessor>()
                .To<UserByIdQueryProcessor>()
                .InRequestScope();
            container.Bind<IUserByLoginQueryProcessor>()
                .To<UserByLoginQueryProcessor>()
                .InRequestScope();

            container.Bind<ILoginInquiryProcessor>()
                .To<LoginInquiryProcessor>()
                .InRequestScope();
            container.Bind<IUserByIdInquiryProcessor>()
                .To<UserByIdInquiryProcessor>()
                .InRequestScope();
        }

        private void ConfigureEntityFramework(IKernel container)
        {
            container.Bind<DbContext>()
                .To<AnalyticsContext>()
                .InRequestScope()
                .WithConstructorArgument("connectionString", GetConnectionStrign("local"));
        }

        private string GetConnectionStrign(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        private void ConfigureAutoMapper(IKernel container)
        {
            container.Bind<IAutoMapper>().To<AutoMapperAdapter>().InSingletonScope();

            container.Bind<IAutoMapperTypeConfigurator>()
                .To<UserEntityToUserMapperTypeConfigurator>()
                .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<SubdivisionEntityToSubdivisionMapperTypeConfigurator>()
                .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<SupplierEntityToSupplierMapperTypeConfigurator>()
                .InSingletonScope();
            container.Bind<IAutoMapperTypeConfigurator>()
                .To<DocumentEntityToDocumentMapperTypeConfigurator>()
                .InSingletonScope();
        }
    }
}