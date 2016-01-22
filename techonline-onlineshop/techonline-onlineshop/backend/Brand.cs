using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineFrontend.backend
{
    public class Brand
    {
        public int id { get; }
        public String name { get; }
        public int total { get; }

        public Brand(int id, String name, int total)
        {
            this.id = id;
            this.name = name;
            this.total = total;
        }
    }
}