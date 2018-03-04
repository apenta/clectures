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