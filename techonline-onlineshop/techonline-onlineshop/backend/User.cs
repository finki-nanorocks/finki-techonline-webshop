using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class User
    {
        public short id { get; set; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public String Username { get; set; }
        public String Sex { get; set; }
        private DateTime Birthday { get; set; }
        public bool isAdmin { get; set; }

        public User(String Name, String Lastname, String Username, String Sex, DateTime Birthday)
        {
            this.Name = Name;
            this.Lastname = Lastname;
            this.Username = Username;
            this.Sex = Sex;
            this.Birthday = Birthday;
        }

    }
}