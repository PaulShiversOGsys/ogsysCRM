using Autofac;
using Autofac.Integration.Mvc;
using Highway.Data;
using ogsysCRM.Mappings;
using ogsysCRM.Models;
using ogsysCRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ogsysCRM.App_Start
{
    public class AutoFacConfig
    {
        public static void RegisterAutoFac()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterSource(new ViewRegistrationSource());

            builder
                .RegisterType<CRMMapping>()
                .As<IMappingConfiguration>();

            builder
                .RegisterType<Repository>()
                .As<IRepository>();
            builder
                .RegisterType<CRMContextConfiguration>()
                .As<IContextConfiguration>();

            builder
                .Register(c => new DataContext(
                    "DefaultConnection",
                    c.Resolve<IMappingConfiguration>(),
                    c.Resolve<IContextConfiguration>()))
                .As<IDataContext>();

            builder
                .RegisterType<CRMService>()
                .InstancePerLifetimeScope();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}