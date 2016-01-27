using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class Order
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set;  }
        public String payment_method { get; set; }
        public String shipping_address { get; set; }
        public String shipping_city { get; set; }
        public string shipping_postal { get; set;  }
        public string shipping_country { get; set; }
        public string date { get; set; }


        public Order(int order_id, int pid, int qty, string payment_method, string shipping_city, string shipping_address, string shipping_postal, string shipping_country, string date)
        {
            this.order_id = order_id;
            this.product_id = pid;
            this.quantity = qty;
            this.payment_method = payment_method;
            this.shipping_address = shipping_address;
            this.shipping_city = shipping_city;
            this.shipping_postal = shipping_postal;
            this.shipping_country = shipping_country;
            this.date = date;
        }

        public Order()
        {

        }
    }

}