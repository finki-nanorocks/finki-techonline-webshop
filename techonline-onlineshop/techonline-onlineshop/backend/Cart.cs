using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace techonline_onlineshop.backend
{
    public class Cart
    {
        public List<CartItem> CartItems;

        public Cart()
        {
            this.CartItems = new List<CartItem>();
        }

        public void AddToCart(Product p)
        {
            this.CartItems.Add(new CartItem(p, 1));
        }

        public void AddToCart(CartItem i, int quantity)
        {
            this.CartItems.Add(new CartItem(p, quantity));
        }

        public double GetTotalPrice()
        {
            double total = 0.0;
            foreach(CartItem item in this.CartItems)
            {
                if(item.quantity > 0)
                {
                    total += item.product.Price * item.quantity;
                }
               
            }
            return total;
        }


    }

}