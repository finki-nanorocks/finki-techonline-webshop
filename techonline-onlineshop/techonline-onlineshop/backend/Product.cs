using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class Product
    {
        public int id { get; }
        public String name { get; }
        public String image_path { get; }
        public String description { get; }
        public int ram_amount { get; }
        public String ram_type { get; }
        public Double cpu_freq { get; }
        public String cpu_brand { get; }
        public int hdd_amount { get; }
        public String hdd_brand { get; }
        public String gpu { get; }
        public int display { get; }
        public String cat_name { get; }
        public Double price { get; }
        public Double discount { get; }

        public Product(int id, String name, String image_path, String description, int ram_amount, String ram_type, 
                       Double cpu_freq, String cpu_brand, int hdd_amount, String hdd_brand, 
                       String gpu, int display, String cat_name, Double price, Double discount)
        {
            this.id = id;
            this.name = name;
            this.image_path = image_path;
            this.description = description;
            this.ram_amount = ram_amount;
            this.ram_type = ram_type;
            this.cpu_freq = cpu_freq;
            this.cpu_brand = cpu_brand;
            this.hdd_amount = hdd_amount;
            this.hdd_brand = hdd_brand;
            this.gpu = gpu;
            this.display = display;
            this.cat_name = cat_name;
            this.price = price;
            this.discount = discount;
        }


        public String getHdd()
        {
            return this.hdd_amount + " " + this.hdd_brand;
        }
        
        public String getRam()
        {
            return this.ram_amount + " " + this.ram_type;
        }
        public String getCpu()
        {
            return this.cpu_brand + " " + this.cpu_freq;
        }
    }


}