using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;

namespace techonline_onlineshop
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( ! Page.IsPostBack)
            {
                ShoppingCart currentCart = (ShoppingCart)HttpContext.Current.Session["currentCart"];
                tblCart.InnerHtml = HtmlGenerator.NEWCartItemsHTML(currentCart.CartItems);
            }

        }
    }
}