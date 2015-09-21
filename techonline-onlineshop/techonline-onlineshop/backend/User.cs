using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class User
    {
        public String Name { get; set; }
        public String Lastname { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        public bool isAdmin { get; set; }

        public User(String Name, String Lastname, String Email, String Password)
        {
            this.Name = Name;
            this.Lastname = Lastname;
            this.Email = Email;
            this.Password = Password;
        }

    }
}