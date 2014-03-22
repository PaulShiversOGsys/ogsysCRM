using Autofac;
using Autofac.Integration.Mvc;
using Highway.Data;
using Highway.Data.EntityFramework;
using ogsysCRM.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ogsysCRM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegiterAutoFac();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void RegiterAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<CustomerMapping>().As<IMappingConfiguration>();
            builder.RegisterType<Repository>().As<IRepository>();
            builder
                .Register(c => new DataContext("DefaultConnection", c.Resolve<IMappingConfiguration>()))
                .As<IDataContext>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
