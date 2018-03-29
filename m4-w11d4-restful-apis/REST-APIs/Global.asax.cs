using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using REST_APIs.DAL;
using System.Web.Http;
using Ninject.Web.WebApi;



namespace REST_APIs
{
    public class MvcApplication : NinjectHttpApplication
    {


        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Map Interfaces to Classes
            kernel.Bind<IFilmDAL>().To<FakeFilmDAL>();

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }
    }
}
