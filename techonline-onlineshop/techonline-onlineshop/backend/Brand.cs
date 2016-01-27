using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class Brand
    {
        
        private int _id;
        private String _name;
        private int _total;
        public int id { get { return _id; } set { _id = value; } }
        public String name { get { return _name; } set { _name = value; } }
        public int total { get { return _total; } set { _total = value; } }

        public Brand(int id, String name, int total)
        {
            this.id = id;
            this.name = name;
            this.total = total;
        }

        public Brand()
        {

        }
    }
}