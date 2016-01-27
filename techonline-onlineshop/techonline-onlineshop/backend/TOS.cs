using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TechonlineAPI
{
    public class TOS : IDisposable
    {
        public static readonly bool WITH_PASSWORD = true;
        public static readonly String LAPTOPS_IMG_URL = "/images/laptop/"; 

        //Singleton instance
        private static TOS instance = null;

        //Connection related
        private String connectionString { get; set; }
        private SqlConnection connection { get; set; }

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
                        int id = Convert.ToInt32(reader["id"]);
                        String name = Convert.ToString(reader["name"]);
                        String lastname = Convert.ToString(reader["lastname"]);
                        String _email = Convert.ToString(reader["email"]);
                        String type = Convert.ToString(reader["type"]);
                        String signup_date = Convert.ToString(reader["signup_date"]);

                        user = new User(name, lastname, _email, type, signup_date);
                        user.id = id;

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

            return affected > 0;
        }


        public List<Brand> getAllBrands()
        {
            List<Brand> brands = new List<Brand>();

            String sstr = "SELECT C.id, C.cat_name, COUNT(*) as total FROM categories C, products P WHERE C.id = P.category GROUP BY C.id, C.cat_name";
            using (SqlCommand cmd = new SqlCommand(sstr, connection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    String name = Convert.ToString(reader["cat_name"]);
                    int total = Convert.ToInt32(reader["total"]);
                    brands.Add( new Brand(id, name, total ) );
                }
                reader.Close();
            }
           return brands;
        }

        public Product getProduct(int product_id)
        {
            String query = "SELECT * FROM products, categories WHERE products.category=categories.id AND products.id=@id";
            Product p = null;

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", product_id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    String name = Convert.ToString(reader["name"]);
                    String image_path = Convert.ToString(reader["image_path"]);
                    String description = Convert.ToString(reader["description"]);
                    int ram_amount = Convert.ToInt16(reader["ram_amount"]);
                    String ram_type = Convert.ToString(reader["ram_type"]);
                    Double cpu_freq = Convert.ToDouble(reader["cpu_freq"]);
                    String cpu_brand = Convert.ToString(reader["cpu_brand"]);
                    int hdd_amount = Convert.ToInt32(reader["hdd_amount"]);
                    String hdd_brand = Convert.ToString(reader["hdd_brand"]);
                    String gpu = Convert.ToString(reader["gpu"]);
                    int display = Convert.ToInt16(reader["display"]);
                    int category = Convert.ToInt32(reader["category"]);
                    String cat_name = Convert.ToString(reader["cat_name"]);
                    Double price = Convert.ToDouble(reader["price"]);
                    var discount = reader["discount"] as string;

                    int i = 0;
                    if ( ! string.IsNullOrWhiteSpace(Convert.ToString(discount)))
                    {
                        
                        i = Convert.ToInt32(discount);
                    }
                    p = new Product(
                            id, name, image_path, description, ram_amount, ram_type, cpu_freq, cpu_brand, hdd_amount, hdd_brand, gpu, display, cat_name, price, i
                        );
                }
                reader.Close();
            }
            return p;
        }

        public List<Product> getProducts(int brand)
        {

            List<Product> products = new List<Product>();
            String query;
            if (brand > -1)
            {
                query = "SELECT * FROM products, categories WHERE products.category=categories.id AND products.category=@id";
            }
            else
            {
                query = "SELECT * FROM products, categories WHERE products.category=categories.id";
            }
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {

                if(brand > -1)
                {
                    cmd.Parameters.AddWithValue("@id", brand);
                }
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    String name = Convert.ToString(reader["name"]);
                    String image_path = Convert.ToString(reader["image_path"]);
                    String description = Convert.ToString(reader["description"]);
                    int ram_amount = Convert.ToInt16(reader["ram_amount"]);
                    String ram_type = Convert.ToString(reader["ram_type"]);
                    Double cpu_freq = Convert.ToDouble(reader["cpu_freq"]);
                    String cpu_brand = Convert.ToString(reader["cpu_brand"]);
                    int hdd_amount = Convert.ToInt32(reader["hdd_amount"]);
                    String hdd_brand = Convert.ToString(reader["hdd_brand"]);
                    String gpu = Convert.ToString(reader["gpu"]);
                    int display = Convert.ToInt16(reader["display"]);
                    int category = Convert.ToInt32(reader["category"]);
                    String cat_name = Convert.ToString(reader["cat_name"]);
                    Double price = Convert.ToDouble(reader["price"]);
                    var discount = reader["discount"] as string;

                    int i = 0;
                    if (string.IsNullOrWhiteSpace(Convert.ToString(discount)))
                    {
                        Debug("Discount null");
                    }
                    else
                    {
                        i = Convert.ToInt32(discount);
                    }

                    products.Add(new Product(
                            id, name, image_path, description, ram_amount, ram_type, cpu_freq, cpu_brand, hdd_amount, hdd_brand, gpu, display, cat_name, price, i
                        ));
                }
                reader.Close();
            }

            return products;
        }

        public bool insertOrder(int user_id, int product_id, int quantity, string payment_method, string shipping_address, string shipping_city, string shipping_postal, string shipping_country)
        {
            int affected = 0;

            String istr = "INSERT INTO orders (user_id, product_id, quantity, payment_method, shipping_address, shipping_city, shipping_postal, shipping_country, date) VALUES(@user_id, @product_id, @quantity, @payment_method, @shipping_address, @shipping_city, @shipping_postal, @shipping_country, @date)";
            using (SqlCommand cmd = new SqlCommand(istr, connection))
            {
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@product_id", product_id);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@payment_method", payment_method);
                cmd.Parameters.AddWithValue("@shipping_address", shipping_address);
                cmd.Parameters.AddWithValue("@shipping_city", shipping_city);
                cmd.Parameters.AddWithValue("@shipping_postal", shipping_postal);
                cmd.Parameters.AddWithValue("@shipping_country", shipping_country);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                try
                {
                    affected = cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    this.Debug("ERROR INSERT ORDER");
                    return false;
                }
            }

            return affected > 0;
        }

        public List<Order> getUserOrders(int user_id)
        {
            String query = "SELECT * FROM orders WHERE orders.user_id=@uid ORDER BY orders.date DESC";
            List<Order> orders = new List<Order>();

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@uid", user_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int order_id = Convert.ToInt32(reader["order_id"]);
                    int product_id = Convert.ToInt32(reader["product_id"]);
                    int qty = Convert.ToInt32(reader["quantity"]);
                    string payment_method = Convert.ToString(reader["payment_method"]);
                    string shipping_city = Convert.ToString(reader["shipping_city"]);
                    string shipping_address = Convert.ToString(reader["shipping_address"]);
                    string shipping_postal = Convert.ToString(reader["shipping_postal"]);
                    string shipping_country = Convert.ToString(reader["shipping_country"]);
                    string date = Convert.ToString(reader["date"]);
                    Order o = new Order(order_id, product_id, qty, payment_method, shipping_city , shipping_address, shipping_postal, shipping_country, date);
                    orders.Add(o);
                }
                reader.Close();
            }
            return orders;
        }

        public bool ChangePassword(string user_email, string oldpassword, string newpassword)
        {
            int affected = 0;

            User usr = this.getUser(user_email, true);

            if(usr != null && usr.Password.Equals(oldpassword))
            {
                String istr = "UPDATE users SET password=@password WHERE email=@user_email";
                using (SqlCommand cmd = new SqlCommand(istr, connection))
                {
                    cmd.Parameters.AddWithValue("@user_email", user_email);
                    cmd.Parameters.AddWithValue("@password", newpassword);
                    try
                    {
                        affected = cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        this.Debug("ERROR UPDATING PASSWORD");
                        return false;
                    }
                }
                return affected > 0;
            }
            return false;


        }

        public String getFullProductImagePath(String path, HttpContext current)
        {
            string siteUrl = current.Request.Url.Scheme + "://" + current.Request.Url.Authority + current.Request.ApplicationPath.TrimEnd('/');
            return siteUrl + TOS.LAPTOPS_IMG_URL + path;
        }

        public String getUrlWithoutQS(HttpContext current)
        {
            string rawurl = current.Request.RawUrl;
            bool hasQuestionMark = false;
            for(int i = 0; i < rawurl.Length; i++)
            {
                if (rawurl[i].Equals('?'))
                {
                    hasQuestionMark = true;

                }
            }

            if(hasQuestionMark)
            {
                string current_url = current.Request.RawUrl.Substring(0, current.Request.RawUrl.IndexOf("?"));
                return current_url;
            }
            return rawurl;
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