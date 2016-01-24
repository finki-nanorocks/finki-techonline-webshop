using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;

namespace TechonlineFrontend
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( ! Page.IsPostBack)
            {
                ShoppingCart currentCart = TOSession.Current.cart;
                if(currentCart.CartItems.Count  <= 0)
                {
                    cartInner.InnerHtml = "<h2>Cart Empty</h2>";
                    cartInner.InnerHtml += "Cart empty. Please <a href='Shop.aspx'><strong>add</strong></a> some products to the cart and comeback here!";
                }else
                {
                    Double t = currentCart.GetTotalPrice();
                    tblCart.InnerHtml = HtmlGenerator.NEWCartItemsHTML(currentCart.CartItems, HttpContext.Current);
                    subtotal.InnerHtml = "$" + Convert.ToString(t);
                    total.InnerHtml = "$" + Convert.ToString(t);
                }
                
            }

        }
    }
}