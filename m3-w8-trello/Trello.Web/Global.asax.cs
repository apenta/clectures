using Ninject;
using Ninject.Web.Common.WebHost;
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
    public class MvcApplication : NinjectHttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //}

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        // Implement this abstract method defined by NinjectHttpApplication
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            // Configure our Binding for DI
            kernel.Bind<ITrelloListDAL>().To<TrelloListDAL>();

            return kernel;
        }
    }
}
