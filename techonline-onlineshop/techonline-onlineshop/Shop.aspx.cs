using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;
using System.Data.SqlClient;
using System.Configuration;
namespace techonline_onlineshop
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           string connectionString = ConfigurationManager.ConnectionStrings["TechonlineConnectionStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM products_info", conn);
            try
            {
                conn.Open();

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
                divProductsContainer.InnerHtml = HtmlGenerator.NEWProductsPageItems(allProducts);
            }catch(Exception err){}

            /*Database db = (Database)Application["DB"];
            List<Product> allProducts = db.GetAllProducts();
            divProductsContainer.InnerHtml = HtmlGenerator.NEWProductsPageItems(allProducts);*/
        }
    }
}