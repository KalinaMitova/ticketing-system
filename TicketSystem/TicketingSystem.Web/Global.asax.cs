using System;
using System.Collections.Generic;
using System.Linq;
namespace TicketingSystem.Web
{
    using System.Data.Entity;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;

    using System.Web.Routing;
    using TicketingSystem.Data;
    using TicketingSystem.Data.Migrations;
    using TicketingSystem.Web.App_Start;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicketingSystemDbContext, Configuration>());
            AutoMapperConfig.Config();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
