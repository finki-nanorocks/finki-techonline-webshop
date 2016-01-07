using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;
using System.Data.SqlClient;

namespace TechonlineFrontend
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


            //Set header
            if (TOSession.Current.user != null)
            {
                headerWelcomeText.InnerHtml = "Welcome to Techonline, " + TOSession.Current.user.Name + "! ";
                headerLoginLogoutLinks.InnerHtml = "<a href='" + HttpContext.Current.Request.Url.AbsoluteUri + "?logout=true'>Logout</a>";
            }

            //Logout user
            if (!string.IsNullOrWhiteSpace(Request.QueryString["logout"]) && string.Equals(Request.QueryString["logout"], "true"))
            {
                if(TOSession.Current.user != null)
                {
                    TOSession.Current.user = null;
                    Response.Write("<script>alert('You have been logged out successfully!');</script>");
                    String urlWithoutQueryString = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("?"));
                    Response.Redirect(urlWithoutQueryString, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                
            }

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