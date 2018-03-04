using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Trello.Web.DAL;

namespace Trello.Web
{
    // To configure Dependency Injection to work with this
    // Inherit from Abstract Class NinjectHttpApplication
    // Implement the abstract class CreateKernel method
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
