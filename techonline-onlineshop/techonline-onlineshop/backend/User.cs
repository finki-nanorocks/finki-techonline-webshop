using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class User
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Type { get; set; }
        public String RegistredOn { get; set; }
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

        public User()
        {

        }

    }
}