using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace techonline_onlineshop.backend
{
    public class Category
    {
        public int id { get; set; }
        public String Name { get; set; }

        public Category(int id, string Name) {
            this.id = id;
            this.Name = Name;
        }

    }
}