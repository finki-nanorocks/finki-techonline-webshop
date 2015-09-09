using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace techonline_onlineshop.backend
{
    public class Order
    {
        public int id { get; set; }
        public List<Product> orderedProducts { get; set; }

        public Order(List<Product> products)
        {
            this.orderedProducts = products;
        }
    }
}