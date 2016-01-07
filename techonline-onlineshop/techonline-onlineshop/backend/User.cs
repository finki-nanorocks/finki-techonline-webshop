using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class User
    {
        public String Name { get; }
        public String Lastname { get; }
        public String Email { get; }
        public String Password { get; set; } = null;
        public String Type { get; set; }
        public String RegistredOn { get;  }
        public bool isAdmin {
            get {
                return String.Equals(Type.ToLower(), "admin");
            }
        }

        public User(String Name, String Lastname, String Email, String Type, String RegistredOn)
        {
            this.Name = Name;
            this.Lastname = Lastname;
            this.Email = Email;
            //this.Password = Password;
            this.Type = Type;
            this.RegistredOn = RegistredOn;
        }

    }
}