using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class ShoppingCart
    {
        public List<CartItem> CartItems;

        public ShoppingCart()
        {
            this.CartItems = new List<CartItem>();
        }

        public void AddToCart(Product p)
        {
            bool alreadyInCart = false;
            
            foreach (CartItem item in CartItems)
            {
                if (item.product.id == p.id)
                {
                    item.quantity++;
                    alreadyInCart = true;
                    break;
                }
            }

            if(!alreadyInCart)
            {
                this.CartItems.Add(new CartItem(p, 1));
            }
            
        }

        public void AddToCart(Product p, int quantity)
        {
            this.CartItems.Add(new CartItem(p, quantity));
        }

        public double GetTotalPrice()
        {
            double total = 0.0;
            foreach (CartItem item in this.CartItems)
            {
                if (item.quantity > 0)
                {
                    total += ((item.product.price + 0) * item.quantity);
                }

            }
            return total;
        }

        public double GetTotalShippingPrice()
        {
            double total = 0.0;
            foreach (CartItem item in this.CartItems)
            {
                if (item.quantity > 0)
                {
                    total += 1 * item.quantity;
                }

            }

            return total;

        }

        public double GetTotalWithoutShipping()
        {
            return Math.Abs(this.GetTotalPrice() - this.GetTotalShippingPrice());
        }

        public int TotalCount()
        {
            int total = 0;

            foreach(CartItem i in CartItems)
            {
                total += i.quantity;
            }

            return total;
        }


    }

}