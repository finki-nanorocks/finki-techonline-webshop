using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;
using System.Data.SqlClient;
using System.Configuration;
using TechonlineAPI;

namespace TechonlineFrontend
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String x = "";

            //display add to cart successful messages
            if(Request.QueryString["atc_status"] != null && 1 == Convert.ToInt32(Request.QueryString["atc_status"]))
            {

                displaymsgs.InnerHtml = HtmlGenerator.success("Your product has been added to the cart!");
            }


            //Set brands
            List<Brand> xbrands = TOS.Instance.getAllBrands();
            int totalSum = 0;
            foreach(Brand b in xbrands)
            {
                totalSum += b.total;
                brands.InnerHtml += "<li><a href='/Shop.aspx?brand=" + b.id + "'>" + b.name + " (" + b.total + ")</a><li>";
            }
            brands.InnerHtml += "<li><a href='/Shop.aspx'>All (" + totalSum + ")</a><li>";

            ///Set Products
            List<Product> all;
            if (Request.QueryString["brand"] != null)
            {
                int brand_id = Convert.ToInt32(Request.QueryString["brand"]);
                //TOS.Instance.Debug(":BRAND_ID " + brand_id);
                all = TOS.Instance.getProducts(brand_id);
            }
            else
            {
                all = TOS.Instance.getProducts(-1);
            }

            //Loop Products
            
            divProductsContainer.InnerHtml = HtmlGenerator.NEWShopContents(all, HttpContext.Current);
        }
    }
}