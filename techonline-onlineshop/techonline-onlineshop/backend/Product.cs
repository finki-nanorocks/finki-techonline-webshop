using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class Product
    {
        private int _id;
        private String _name;
        private String _image_path;
        private String _description;
        private int _ram_amount;
        private String _ram_type;
        private Double _cpu_freq;
        private String _cpu_brand;
        private int _hdd_amount;
        private String _hdd_brand;
        private String _gpu;
        private int _display;
        private String _cat_name;
        private Double _price;
        private Double _discount;


        public int id { get { return _id; } set { _id = value;  } }
        public String name { get { return _name; } set { _name = value; } }
        public String image_path { get { return _image_path; } set { _image_path = value; } }
        public String description { get { return _description; } set { _description = value; } }
        public int ram_amount { get { return _ram_amount; } set { _ram_amount = value; } }
        public String ram_type { get { return _ram_type; } set { _ram_type = value; } }
        public Double cpu_freq { get { return _cpu_freq; } set { _cpu_freq = value; } }
        public String cpu_brand { get { return _cpu_brand; } set { _cpu_brand = value; } }
        public int hdd_amount { get { return _hdd_amount; } set { _hdd_amount = value; } }
        public String hdd_brand { get { return _hdd_brand; } set { _hdd_brand = value; } }
        public String gpu { get { return _gpu; } set { _gpu = value; } }
        public int display { get { return _display; } set { _display = value; } }
        public String cat_name { get { return _cat_name; } set { _cat_name = value; } }
        public Double price { get { return _price; } set { _price = value; } }
        public Double discount { get { return _discount; } set { _discount = value; } }

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

        public Product()
        {

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