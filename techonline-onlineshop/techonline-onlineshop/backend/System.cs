using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;


namespace TechonlineAPI
{
    public class System
    {
        private static System instance = null;
        private String connectionString { get; set; }

        //Constructor
        private System()
        {
            this.connectionString = this.getConnectionString();
        }
        
        //Thread safe object
        private static object synchronizactionLock = new object();

        //Singleton
        public static System Instance
        {
            get
            {
                lock (synchronizactionLock)
                {
                    if (System.instance == null)
                        System.instance = new System();
                    return System.instance;
                }
            }
        }

        public String getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["techonlineconnstr"].ConnectionString;
        }

    }
}