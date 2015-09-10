using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class Product
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public double PriceShipping { get; set; }
        public int Category { get; set; }


        public Product(int id, String Name, String Description, double Price, double PriceShipping, int Category)
        {
            this.id = id;
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.PriceShipping = PriceShipping;
            this.Category = Category;
           
        }
    }
}