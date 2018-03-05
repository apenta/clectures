using Forms.Web.DAL;
using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {            
            return View("Index");
        }

        public ActionResult BlankForm()
        {
            return View("BlankForm");
        }

        // Create an action to receive the submitted form
        // Each of the parameters corresponds with an input element from a form
        //public ActionResult FormResult(string name, string password, string subscribe, string gender, string state, string favoriteColor)
        //{
        //    // call dal with the search parameters

        //        return View("FormResult");
        //}

        public ActionResult FormResult(FormModel request)
        {
            return View("FormResult");
        }




        /// <summary>
        /// In lieu of setting up a database, this method will simply log all of the Request Variables
        /// to a file. This will help us better understand the importance of Post-Redirect-Get when we
        /// learn about POST forms.
        /// </summary>
        private void LogRequestToFile()
        {
            Request.InputStream.Position = 0;
            var input = new StreamReader(Request.InputStream).ReadToEnd();
            var name = $"{Request.HttpMethod} - {DateTime.Now.ToString("MM-dd-yyyy hh-mm-ss")}.txt";
            var path = Path.Combine(Server.MapPath("~/bin"), name);
            System.IO.File.WriteAllText(path, input);
        }
    }
}