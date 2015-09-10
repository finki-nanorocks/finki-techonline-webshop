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

        public ShoppingCart ShoppingCart { get; set; }

        public _default()
        {
            this.ShoppingCart = new ShoppingCart();
            this.ShoppingCart.AddToCart(new TechonlineAPI.Product(1, "Lenovo G780", "Lenovo G780 Laptop with front camera nad 8gb Ram", 855, 19, 1), 2);
            this.ShoppingCart.AddToCart(new TechonlineAPI.Product(1, "ASUS MemoPAD HD10", "Highperformance ASUS Tablet", 225, 15, 1));
            this.ShoppingCart.AddToCart(new TechonlineAPI.Product(1, "Samsung Galaxy S6", "The newest Samsung Flagship", 900, 50, 1), 1);
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UpdateHeaderCart();
        }

        private void UpdateHeaderCart()
        {
            ulCartDropdown.InnerHtml = HtmlGenerator.addCartDropdownItem(this.ShoppingCart.CartItems);
            lblCartItemCount.Text = Convert.ToString(this.ShoppingCart.CartItems.Count);
            lblCartPrice.Text = Convert.ToString(this.ShoppingCart.GetTotalPrice());
            lblPriceShipping.Text = Convert.ToString(this.ShoppingCart.GetTotalShippingPrice());
            lblPriceTotal.Text = Convert.ToString(this.ShoppingCart.GetTotalWithoutShipping());
        }
    }
}