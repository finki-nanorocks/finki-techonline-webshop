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
                    string redirect = TOS.Instance.getUrlWithoutQS(this.Context);
                    Response.Redirect(redirect, false);
                    Context.ApplicationInstance.CompleteRequest();
                }

                // Update cart
                this.UpdateHeaderCart();
            }


            //Set header
            if (TOSession.Current.user != null)
            {
                headerWelcomeText.InnerHtml = "Welcome to Techonline, <strong>" + TOSession.Current.user.Name + "</strong>!";
                headerLoginLogoutLinks.InnerHtml = "<a href='" + HttpContext.Current.Request.Url.AbsoluteUri + "?logout=true'>Logout</a>";
            }

            //Logout user
            if (!string.IsNullOrWhiteSpace(Request.QueryString["logout"]) && string.Equals(Request.QueryString["logout"], "true"))
            {
                if(TOSession.Current.user != null)
                {
                    TOSession.Current.user = null;
                    Response.Write("<script>alert('You have been logged out successfully!');</script>");
                    Response.Redirect("home.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                
            }

            ///Add To Cart
            if (Request.QueryString["add_to_cart"] != null)
            {
                int product_id = Convert.ToInt32(Request.QueryString["add_to_cart"]);
                Product p = TOS.Instance.getProduct(product_id);
                if(p != null)
                {
                    TOSession.Current.cart.AddToCart(p);
                    string redirect = Request.RawUrl.Substring(0, Request.RawUrl.IndexOf("?"));
                    Response.Redirect(redirect + "?atc_status=1", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    TechonlineAPI.TOS.Instance.Debug("Problem retreiving product");
                }
                
            }

        }

        private void UpdateHeaderCart()
        {
            if(TOSession.Current.cart != null)
            {
                ShoppingCart currentCart = TOSession.Current.cart;
                ulCartDropdown.InnerHtml = HtmlGenerator.NEWCartDropdownItemHTML(currentCart.CartItems, HttpContext.Current);
                lblCartItemCount.Text = Convert.ToString(currentCart.TotalCount());
                lblCartPrice.Text = Convert.ToString(currentCart.GetTotalPrice());
               // lblPriceShipping.Text = Convert.ToString(currentCart.GetTotalShippingPrice());
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

            if (TOSession.Current.cart  != null)
            {
                ShoppingCart crt = TOSession.Current.cart;
                List<CartItem> items = crt.CartItems;
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].product.id == cartItemId)
                    {
                        items.RemoveAt(i);
                    }
                }
                crt.CartItems = items;
                TOSession.Current.cart = crt;
            }
        }
    }
}