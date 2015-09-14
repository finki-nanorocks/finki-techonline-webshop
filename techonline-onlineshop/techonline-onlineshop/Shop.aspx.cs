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
            String str = ConfigurationManager.ConnectionStrings["TechonlineConnectionStr"].ConnectionString;
            SqlConnection connection = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SELECT * FROM products_info", connection);
            connection.Open();
            SqlDataReader r = cmd.ExecuteReader();
            List<Product> allProducts = new List<Product>();

            while (r.Read())
            {
                allProducts.Add(new Product(
                    Convert.ToInt32(r.GetString(0)), //ID
                    Convert.ToString(r.GetString(1)), //Type
                    Convert.ToString(r.GetString(2)), // Brand
                    Convert.ToString(r.GetString(3)), // Model
                    Convert.ToString(r.GetString(4)), // CPU
                    Convert.ToString(r.GetString(5)), // RAM
                    Convert.ToString(r.GetString(6)), // HDD
                    Convert.ToString(r.GetString(7)), // HDD
                    Convert.ToString(r.GetString(8)), //OS
                    Convert.ToString(r.GetString(9)), //more_info
                    Convert.ToDouble(r.GetDouble(10)) //Price
                 ));
            }


            divProductsContainer.InnerHtml = HtmlGenerator.NEWProductsPageItems(allProducts);
        }
    }
}