using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;
using System.Data.SqlClient;
using System.Configuration;
using TechonlineFrontend.backend;

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
            String html = "<div class='row'>";
            for(int i = 0, j = 0; i < all.Count; i++)
            {
                j++;
                if (j == 0) {}
                string siteUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath.TrimEnd('/');
                html += "<div class='col-sm-4'>";
                html += "<div class='item item-hover'>";
                html += "<div class='item-image-wrapper'>";
                html += "<figure class='item-image-container'><a href='product.html'><img class='item-image' alt='item1' src='"+ siteUrl  + TOS.LAPTOPS_IMG_URL + all[i].image_path +"'></a></figure>";
                html += "<div class='item-price-container'><span class='item-price'>$" + Convert.ToString(all[i].price) + "</span></div>";
                html += "</div>";
                html += "<div class='item-meta-container'>";
                html += "<h3 class='item-name'><a href='product.html'>" + Convert.ToString(all[i].name) + "</a></h3>";
                html += "<div class='item-action'>";
                html += "<a class='item-add-btn' href='?add_to_cart=" + all[i].id  + "'><span class='icon-cart-text'>Add to Cart</span></a>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                if(j == 3)
                {
                    html += "</div><div class='row'>";
                    j = 0;
                }
            }
            html += "</div>"; //close oepend row
            divProductsContainer.InnerHtml = html;
        }
    }
}