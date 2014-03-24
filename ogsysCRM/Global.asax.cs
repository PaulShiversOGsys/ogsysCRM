using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Highway.Data;
using Highway.Data.EntityFramework;
using ogsysCRM.App_Start;
using ogsysCRM.Mappings;
using ogsysCRM.Models;
using ogsysCRM.Services;
using ogsysCRM.ViewModels;
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
            AutoFacConfig.RegisterAutoFac();
            AutoMapperConfig.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
