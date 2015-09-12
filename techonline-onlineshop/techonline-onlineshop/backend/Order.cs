using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class Order
    {
        public ShoppingCart oredredCart { get; set; }

        public Order(ShoppingCart orderedCart)
        {
            this.oredredCart = orderedCart;
        }
          
    }
}