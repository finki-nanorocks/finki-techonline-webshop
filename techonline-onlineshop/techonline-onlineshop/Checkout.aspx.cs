using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TechonlineAPI;

namespace TechonlineFrontend
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!Page.IsPostBack)
            {
                //Check if user is logged in
                if(TOSession.Current.user != null)
                {

                    //Set user id in the checkout form
                    HtmlInputHidden checkoutUserId = new HtmlInputHidden();
                    checkoutUserId.ID = "checkoutUserId";
                    checkoutUserId.Name = "user_id";
                    checkoutUserId.Value = Convert.ToString(TOSession.Current.user.id);
                    submitPnl.Controls.Add(checkoutUserId);

                    //Check if cart is not empty
                    if (TOSession.Current.cart != null && TOSession.Current.cart.CartItems.Count > 0)
                    {
                        tblCheckout.InnerHtml = HtmlGenerator.NEWCartItemsHTML(TOSession.Current.cart.CartItems, HttpContext.Current);
                    }
                    else
                    {
                        checkoutInner.InnerHtml = "<h2>Cart empty</h2>";
                        checkoutInner.InnerHtml += "<p>Please <a href='Shop.aspx'><strong>add</strong></a> some products to the cart and checkout again!</p>";
                    }
                }
                else
                {
                    checkoutInner.InnerHtml = "<h2>Not logged in</h2>";
                    checkoutInner.InnerHtml += "<p>Please <a href='login.aspx'><strong>login</strong></a> to continue!</p>";
                }

            }


            //Checkout results
            if (Request.QueryString["status"] != null && Convert.ToString(Request.QueryString["status"]).Equals("1"))
            {
                checkoutStatus.InnerHtml = HtmlGenerator.success("Order successful. Please wait for our confirmation!");
            }
            else if (Request.QueryString["status"] != null && Convert.ToString(Request.QueryString["status"]).Equals("400"))
            {
                checkoutStatus.InnerHtml = HtmlGenerator.error("Error inserting into database! Please contact tech support for assistance");
            }
            else if (Request.QueryString["status"] != null && Convert.ToString(Request.QueryString["status"]).Equals("404"))
            {
                checkoutStatus.InnerHtml = HtmlGenerator.error("Please fill all the fields and try again!");
            }

            if (!String.IsNullOrWhiteSpace(Request.Form["submitted"]) && Request.Form["submitted"].Equals("1"))
            {
                //Response.Write("<script>alert('FORM SUBMITTED!!');</script>");

                List<string> fields = new List<string>();
                fields.Add("address1");
                fields.Add("city");
                fields.Add("postal");
                fields.Add("country");
                fields.Add("payment_method");
                bool fieldsValid = true;
                for (int i = 0; i < fields.Count; i++)
                {
                    if (String.IsNullOrWhiteSpace(Request.Form[fields[i]]))
                    {
                        fieldsValid = false;
                        break;
                    }
                }

                if (fieldsValid && TOSession.Current.cart.CartItems.Count > 0)
                {
                    bool inserted = createOrders();

                    if (!inserted)
                    {
                        Response.Redirect("Checkout.aspx?status=400", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        TOSession.Current.cart = new ShoppingCart();
                        Response.Redirect("Checkout.aspx?status=1", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    Response.Redirect("Checkout.aspx?status=404", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }



        }

        private bool createOrders()
        {
            List<CartItem> items = TOSession.Current.cart.CartItems;

            bool inserted = false;

            Int32 user_id = Convert.ToInt32(Request.Form["ctl00$MainContent$checkoutUserId"]);
            String address1 = Convert.ToString(Request.Form["address1"]);
            String city = Convert.ToString(Request.Form["city"]);
            String postal = Convert.ToString(Request.Form["postal"]);
            String country = Convert.ToString(Request.Form["country"]);
            String pm = Convert.ToString(Request.Form["payment_method"]);

            foreach (CartItem item in items)
            {
                Int32 product_id = item.product.id;
                Int32 quantity = item.quantity;

                //TechonlineAPI.TOS.Instance.Debug("COUNTRY: " + country);

                inserted = TOS.Instance.insertOrder(user_id, product_id, quantity, pm, address1, city, postal, country);

                if (!inserted)
                    return false;
            }
            return inserted;
        }
    }
}