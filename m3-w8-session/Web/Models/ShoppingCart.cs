using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();

        public void AddToCart(Product p, int quantity)
        {
            // Find the current item in the cart (if it exists)
            var shoppingCartItem = Items.FirstOrDefault(i => i.Product.Id == p.Id);

            // If it doesn't exist add it as a "Shopping Cart Item"
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem() { Product = p, Quantity = 0 };
                Items.Add(shoppingCartItem);
            }

            // Update the Quantity
            shoppingCartItem.Quantity += quantity;
        }
    }
}