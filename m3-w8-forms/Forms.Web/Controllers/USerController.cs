using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Registration()
        {
            return View();
        }

        //4. Add a Post Action to Process Registration
        [HttpPost]
        public ActionResult Registration(UserRegistrationModel model)
        {
            // code that calls DAL
            return RedirectToAction("Success"); //5. Redirect user to /User/Success
        }

        //6. Add a User/Success action
        public ActionResult Success()
        {
            return View();
        }
    }
}