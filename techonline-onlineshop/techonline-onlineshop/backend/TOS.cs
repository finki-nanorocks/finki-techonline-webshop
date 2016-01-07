using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace TechonlineAPI
{
    public class TOS : IDisposable
    {
        private static readonly bool WITH_PASSWORD = true;

        //Singleton instance
        private static TOS instance = null;

        //Connection related
        private String connectionString { get; set; }
        private SqlConnection connection { get; } = null;

        //Constructor
        private TOS()
        {
            connectionString = this.getConnectionString();
            connection = new SqlConnection(this.connectionString);
            connection.Open();
        }
        
        //Thread safe object
        private static object synchronizactionLock = new object();

        //Singleton
        public static TOS Instance
        {
            get
            {
                lock (synchronizactionLock)
                {
                    if (TOS.instance == null)
                        TOS.instance = new TOS();
                    return TOS.instance;
                }
            }
        }

        //Dispose of Disposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //Implement virtual method
        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                connection.Close();
            }
        }

        //Class Destructor
        ~TOS()
        {
            Dispose(false);
        }

        //Starting
        //Application Methods

        public String getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["techonlineconnstr"].ConnectionString;
        }

        //Check if user is registred
        public bool isUserRegistred( String email )
        {
            int users = 0;

            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM users WHERE email = @email"))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Connection = connection;
                users = (int)cmd.ExecuteScalar();
            }

        
            return users > 0;
        }

        //Get User by Email
        public User getUser(String email, bool includePassword = false)
        {
            User user = null;
            
            if( isUserRegistred( email ) )
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE email = @email"))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Connection = connection;
                
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        String name = Convert.ToString(reader["name"]);
                        String lastname = Convert.ToString(reader["lastname"]);
                        String _email = Convert.ToString(reader["email"]);
                        String type = Convert.ToString(reader["type"]);
                        String signup_date = Convert.ToString(reader["signup_date"]);

                        user = new User(name, lastname, _email, type, signup_date);

                        if (includePassword)
                        {
                            user.Password = Convert.ToString(reader["password"]);
                        }
                    }
                    reader.Close();
                }
            }
            return user;
        }


        //Check if user can login with the combination email - password
        public bool canLogin(String email, String password)
        {
            User user = getUser(email, WITH_PASSWORD);
            return (user != null && String.Equals(user.Password, password));
        }

        //Register user
        public bool register(String name, String lastname, String email, String password, String type)
        {
            int affected = 0;

            if (!isUserRegistred(email))
            {
                String istr = "INSERT users (name, lastname, email, password, signup_date, type) VALUES(@name, @lastname, @email, @password, @now, @type)";
                using (SqlCommand cmd = new SqlCommand(istr, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@lastname", lastname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now.ToString("MMM dd HH:mm:ss"));
                    affected = cmd.ExecuteNonQuery();
                }

            }
            return affected > 0;
        }

        //Email validation
        public bool IsValidEmail(String email)
        {
            EmailAddressAttribute emailObj = new EmailAddressAttribute();
            return emailObj.IsValid(email);
        }

        //Used for debugging purposes
        public void Debug( object o )
        {
            System.Diagnostics.Debug.WriteLine("DEBUG:: " + o);
        }
        

    }
}