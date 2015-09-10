using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class CartItem
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public Product product { get; set; }

        public CartItem(Product p, int quantity = 1)
        {
            this.quantity = quantity;
            this.product = p;
        }
    }
}