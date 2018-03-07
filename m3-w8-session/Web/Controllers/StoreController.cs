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
        public ActionResult AddToCart(int id)
        {
            // Add whichever Product productId represents to the shopping cart

            //1.  Get the Product associated with id
            var product = dal.GetProduct(id);

            //2.  Add Product, qty 1 to our active shopping cart
            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(product, 1);


            return RedirectToAction("ViewCart");
        }


        // Remove 1 product from the shopping cart
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Get the product associated with the id
            var product = dal.GetProduct(id);

            // Find the active shopping cart
            var cart = GetActiveShoppingCart();

            // Remove Qty 1 of product from shopping cart
            cart.RemoveOne(product);

            // Redirect to ViewCart
            return RedirectToAction("ViewCart");
        }








        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            // See if the user has a shopping cart stored in session
            if(Session["Shopping_Cart"] == null)
            {
                cart = new ShoppingCart();
                Session["Shopping_Cart"] = cart;        // <-- saves the shopping cart into session
            }
            else
            {
                cart = Session["Shopping_Cart"] as ShoppingCart; // <-- gets the shopping cart out of session
            }

            // If not, create one for them

            return cart;
        }


        // View the Shopping Cart
        public ActionResult ViewCart()
        {
            // Get our shopping cart and display it in the view
            ShoppingCart cart = GetActiveShoppingCart();


            
            return View(cart);
        }

    }
}