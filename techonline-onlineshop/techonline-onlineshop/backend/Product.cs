using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class Product
    {
        public int id { get; set; }
        public String Type { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public String Cpu { get; set; }
        public String Ram { get; set; }
        public String Hdd { get; set; }
        public String OS { get; set; }
        public String MoreInfo { get; set; }
        public double Price { get; set; }

        public Product(int id, String Type, String Brand, String Model, String Cpu, String Ram, String Hdd, String OS, String MoreInfo, double Price)
        {
            this.id = id;
            this.Type = Type;
            this.Brand = Brand;
            this.Model = Model;
            this.Cpu = Cpu;
            this.Ram = Ram;
            this.Hdd = Hdd;
            this.OS = OS;
            this.MoreInfo = MoreInfo;
            this.Price = Price;
        }
    }
}