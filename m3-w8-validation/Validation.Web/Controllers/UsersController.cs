using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


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

        // POST: User/Login  
        // Validate the model and redirect to login (if successful) or return the 
        // login view (if validation fails)

        // GET: User/Confirmation
        // Return the confirmation view
    }
}