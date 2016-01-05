using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlClient;


namespace TechonlineAPI
{
    public class Database
    {
      // private  string connstring = "Data Source=DARKO-LAPTOP\\SQLEXPRESS;Initial Catalog=db_techonlineGNML;Integrated Security=True";
         public string connstring = "Data Source=NANO\\SQLEXPRESS;Initial Catalog=db_techonlineGNML;Integrated Security=True";
        private string connectionString
        {
            get; set;
        }
        public SqlConnection connection { get; set; }

        public Database()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["TechonlineConnectionStr"].ConnectionString;
            this.Connect();
        }

        public void Connect()
        {
            this.connection = new SqlConnection(this.connectionString);
        }

       /* public List<Product> GetAllProducts()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM products_info", this.connection);
            this.connection.Open();
            SqlDataReader r = cmd.ExecuteReader();

            List<Product> allProducts = new List<Product>();


            while (r.Read())
            {
                Product p = new Product(
                        r.GetInt32(0),
                        r.GetString(1),
                        r.GetString(2),
                        r.GetString(3),
                        r.GetString(4),
                        r.GetString(5),
                        r.GetString(6),
                        r.GetString(8),
                        r.GetString(9),
                        r.GetDouble(10)
                        );

                allProducts.Add(p);
            }

            r.Close();
            this.connection.Close();
            return allProducts;
        }*/


        public void InsertProduct(Product p)
        {

        }
        public void RemoveProduct(Product p)
        {

        }

        public void InsertOrder(ShoppingCart p, User u)
        {

        }
        public void RemoveOrder(User u)
        {

        }

        public void RemoveUser(User u)
        {

        }
        public string checkUser(string email, string pass)
        {
            int tmp = 0;
            string name = ""; // ako ne postoi korisnik vrati ""
            SqlCommand cmd = new SqlCommand("SELECT [name], [password], [email], FROM [User_info] WHERE ([password] = @password) AND ([email] = @email)", this.connection);
            try
            {
                this.connection.Open();
                cmd.Parameters.AddWithValue("@password", pass); // vo slucaj da ne gi najde spored pass i email nema da vrati niso i ke padne , pa zatoa ke vrati false
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    if (read["email"].Equals(email) && read["password"].Equals(pass))
                    {
                        tmp++; // ako postoi korisnik ova moze i da si implementira ako najde i korisnici povekje isti so pass i email :P
                        name = read["name"].ToString();
                    }
                }
                if (tmp != 0)
                {
                    return name; // postoi, zacuvaj gi vo sesija imeto,pass,email treba da se implementira no i ne mora
                }
                this.connection.Close();
                return name;
            }
            catch (Exception err) { 
                this.connection.Close();
                return name;
            }
            return name;
        }

        public void addUser(User u)
        {
            SqlConnection cs = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand("INSERT INTO User_info VALUES (@name,@lastname,@pass,@email,@isadmin);", cs);
            cmd.Parameters.AddWithValue("@name", u.Name);
            cmd.Parameters.AddWithValue("@lastname", u.Lastname);
            cmd.Parameters.AddWithValue("@pass", u.Password); 
            cmd.Parameters.AddWithValue("@email", u.Email);
            cmd.Parameters.AddWithValue("@isadmin", 0);
            try
            {
                cs.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                cs.Close();
            }
            cs.Close();
        }
        public int get_len_client()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM [User_info]", this.connection);
            int tmp = 0;// kolku korisnici
            try
            {
                this.connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                        tmp++;                     
                }
                this.connection.Close();
                return tmp;
            }
            catch (Exception err)
            {
                this.connection.Close();
                return tmp;
            }
            return tmp;
        }
        public int get_len_article()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM [products_info]", this.connection);
            int tmp = 0;// kolku korisnici
            try
            {
                this.connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    tmp++;
                }
                this.connection.Close();
                return tmp;
            }
            catch (Exception err)
            {
                this.connection.Close();
                return tmp;
            }
            return tmp;

        }
        
    }
}