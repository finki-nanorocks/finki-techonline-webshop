using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechonlineAPI
{
    public class Userbase
    {
        public List<User> Users { get; set; }

        public Userbase(User[] Users)
        {
            foreach (User u in Users)
            {
                this.Users.Add(u);
            }
        }

        public void AddUser(User u)
        {
            this.Users.Add(u);
        }
    }

}