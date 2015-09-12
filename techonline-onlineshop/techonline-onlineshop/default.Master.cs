using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;
using System.Data.SqlClient;

namespace techonline_onlineshop
{
    public partial class _default : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if(! Page.IsPostBack)
            {
                // Remove Cart items if event triggered
                if (!string.IsNullOrWhiteSpace(Request.QueryString["deleteCartItem"]))
                {
                    this.removeCartItem();
                }

                // Update cart
                this.UpdateHeaderCart();
            }

           // Database db = (Database)Application.Get("DB");
           // List<Product> allProducts = db.GetAllProducts();

        }

        private void UpdateHeaderCart()
        {
            if(null != HttpContext.Current.Session["currentCart"])
            {
                ShoppingCart currentCart = (ShoppingCart)HttpContext.Current.Session["currentCart"];
                ulCartDropdown.InnerHtml = HtmlGenerator.NEWCartDropdownItemHTML(currentCart.CartItems);
                lblCartItemCount.Text = Convert.ToString(currentCart.CartItems.Count);
                lblCartPrice.Text = Convert.ToString(currentCart.GetTotalPrice());
                lblPriceShipping.Text = Convert.ToString(currentCart.GetTotalShippingPrice());
                lblPriceTotal.Text = Convert.ToString(currentCart.GetTotalWithoutShipping());
            }
            else
            {
                ulCartDropdown.InnerHtml = "";
                lblCartItemCount.Text = "0";
                lblCartPrice.Text = lblPriceShipping.Text = lblPriceTotal.Text = "0.00";

            }
        }
        
        private void removeCartItem()
        {
            int cartItemId = Convert.ToInt32(Request.QueryString["deleteCartItem"]);

            if (HttpContext.Current.Session["currentCart"] != null)
            {
                ShoppingCart crt = (ShoppingCart)Session["currentCart"];
                List<CartItem> items = crt.CartItems;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].product.id == cartItemId)
                    {
                        items.RemoveAt(i);
                    }
                }
                crt.CartItems = items;
                Session["currentCart"] = crt;
            }
        }
    }
}