using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intro_To_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }        

        //1. Create a new action called PersonalGreeting
        public ActionResult PersonalGreeting()
        {
            return View();
        }

        //2. Add a MetricToImperial Action so that the user
        //   can go to /Home/MetricToImperial
        public ActionResult MetricToImperial()
        {
            return View();
        }
    }
}