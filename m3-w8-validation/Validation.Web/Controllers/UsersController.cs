using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationSite.Web.Models;

namespace Validation.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View("Index");
        }

        // Add the following Controller Actions

        // GET: User/Register
        // Return the empty registration view

        // POST: User/Register
        // Validate the model and redirect to confirmation (if successful) or return the 
        // registration view (if validation fails)        

        // GET: User/Login
        // Return the empty login view
        // 1. Create an action to display the empty form
        public ActionResult Login()
        {
            return View();
        }

        // POST: User/Login  
        // Validate the model and redirect to login (if successful) or return the 
        // login view (if validation fails)
        // 4. Create an action to process the login data
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //10. Enforce the validation
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return View("Login", model); //<-- pass in the model to show them their 
            }
        }

        // GET: User/Confirmation
        // Return the confirmation view
        // 6. Create an action that will return a Success Page
        public ActionResult Success()
        {
            return View();
        }






    }
}