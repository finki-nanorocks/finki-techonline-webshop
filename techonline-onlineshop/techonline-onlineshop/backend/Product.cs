using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace techonline_onlineshop.backend
{
    public class Product
    {
        public short id { get; set; }

        public String Name { get; set; }

        public Double Price { get; set; }

        public List<int> CategoriesBelong { get; set; }

        public Product(int id, String Name, Double Price, List<int> categories)
        {
            this.id = id;
            this.Name = Name;
            this.Price = Price;
            this.CategoriesBelong = categories;
        }
    }
}