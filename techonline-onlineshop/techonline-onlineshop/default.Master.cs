using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;

namespace techonline_onlineshop
{
    public partial class _default : System.Web.UI.MasterPage
    {
        //FOR TESTING PURPOSES
        public _default()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Fullfill the session with some products for testing
            if (HttpContext.Current.Session["currentCart"] == null)
            {
                ShoppingCart curr = new ShoppingCart();
                curr.AddToCart(new TechonlineAPI.Product(1, "Lenovo G780", "Lenovo G780 Laptop with front camera nad 8gb Ram", 855, 19, 1), 2);
                curr.AddToCart(new TechonlineAPI.Product(2, "ASUS MemoPAD HD10", "Highperformance ASUS Tablet", 225, 15, 1));
                curr.AddToCart(new TechonlineAPI.Product(3, "Samsung Galaxy S6", "The newest Samsung Flagship", 900, 50, 1), 1);
                Session["currentCart"] = curr;
            }

            // Remove Cart items if event triggered
            if( ! string.IsNullOrWhiteSpace(Request.QueryString["deleteCartItem"]))
            {

                this.removeCartItem();
            }

            // Update cart
            this.UpdateHeaderCart();
        }

        private void UpdateHeaderCart()
        {
            if(null != HttpContext.Current.Session["currentCart"])
            {
                ShoppingCart currentCart = (ShoppingCart)HttpContext.Current.Session["currentCart"];
                ulCartDropdown.InnerHtml = HtmlGenerator.addCartDropdownItem(currentCart.CartItems);
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