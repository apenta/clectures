using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class StoreController : Controller
    {
        IProductDAL dal;
        public StoreController(IProductDAL dal)
        {
            this.dal = dal;
        }

        
        // Display All of the Products
        public ActionResult Index()
        {
            var products = dal.GetProducts();

            return View("Index", products);
        }

        // Add a Product to the Shopping Cart
        [HttpPost]
        public ActionResult AddToCart(/*int productId*/)
        {
            // Add whichever Product productId represents to the shopping cart

            return RedirectToAction("ViewCart");
        }

        
        // View the Shopping Cart
        public ActionResult ViewCart()
        {
            // Get our shopping cart and display it in the view
            
            return View();
        }

    }
}