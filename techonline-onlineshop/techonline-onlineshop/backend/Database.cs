using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace TechonlineAPI
{
    public class Database
    {
       // private readonly string connstring = "Data Source=DARKO-LAPTOP\\SQLEXPRESS;Initial Catalog=db_techonlineGNML;Integrated Security=True";
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

        public List<Product> GetAllProducts()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM products_info", this.connection);
            this.connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Product> allProducts = new List<Product>();

            if(reader.HasRows)
            {
                while ( reader.NextResult() )
                {
                    Product p = new Product(
                                    Convert.ToInt32(reader.GetValue(0)), 
                                    Convert.ToString(reader.GetValue(1)), 
                                    Convert.ToString(reader.GetValue(2)), 
                                    Convert.ToString(reader.GetValue(3)), 
                                    Convert.ToString(reader.GetValue(4)), 
                                    Convert.ToString(reader.GetValue(5)), 
                                    Convert.ToString(reader.GetValue(6)), 
                                    Convert.ToString(reader.GetValue(7)), 
                                    Convert.ToString(reader.GetValue(8)), 
                                    Convert.ToDouble(reader.GetValue(9))
                                );
                    allProducts.Add(p);
                }
            }
            reader.Close();
            this.connection.Close();
            return allProducts;
        }


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

        public void InsertNewUser(User u)
        {

        }

        public void RemoveUser(User u)
        {

        }
    }
}