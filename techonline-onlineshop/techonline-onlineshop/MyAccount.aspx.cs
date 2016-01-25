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
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TOSession.Current.user != null)
            {
                if (!Page.IsPostBack)
                {
                    //Set user id in the checkout form
                    HtmlInputHidden uemail = new HtmlInputHidden();
                    uemail.ID = "uemail";
                    uemail.Name = "uemail";
                    uemail.Value = TOSession.Current.user.Email;
                    cpform.Controls.Add(uemail);

                    accountName.InnerHtml = "Welcome, " + TOSession.Current.user.Name;
                    useremail.Value = TOSession.Current.user.Email;
                    List<Order> orders = TOS.Instance.getUserOrders(TOSession.Current.user.id);

                    if(orders.Count > 0)
                    {
                        tblPreviousPurchases.InnerHtml = HtmlGenerator.NEWPreviousPurchasesTable(orders, this.Context);
                    }
                    else
                    {
                        tblPreviousPurchases.InnerHtml = "<tr><td colspan='6'>No previous orders found.</td></tr>";
                    }
                    
                }

                //Checkout results
                if (Request.QueryString["status"] != null && Convert.ToString(Request.QueryString["status"]).Equals("1"))
                {
                    passwordStatus.InnerHtml = HtmlGenerator.success("Password updated successfully!");
                }
                else if (Request.QueryString["status"] != null && Convert.ToString(Request.QueryString["status"]).Equals("400"))
                {
                    passwordStatus.InnerHtml = HtmlGenerator.error("Error updating password! Please contact tech support for assistance");
                }
                else if (Request.QueryString["status"] != null && Convert.ToString(Request.QueryString["status"]).Equals("404"))
                {
                    passwordStatus.InnerHtml = HtmlGenerator.error("Please fill all the fields correctly and try again!");
                }


                if (!String.IsNullOrWhiteSpace(Request.Form["submitted"]) && Convert.ToString(Request.Form["submitted"]).Equals("Change"))
                {

                    List<string> fields = new List<string>();
                    
                    fields.Add("ctl00$MainContent$uemail");
                    fields.Add("useroldpass");
                    fields.Add("usernewpass");
                    fields.Add("userconfirmpass");
                    bool allSet = true;
                    for(int i = 0; i < fields.Count; i++)
                    {
                        if(String.IsNullOrWhiteSpace(Request.Form[fields[i]]))
                        {
                            TOS.Instance.Debug("FIELD " + fields[i] + " NOT VALID");
                            allSet = false;
                            break;
                        }
                    }

                    if(allSet)
                    {
                        bool updated = TOS.Instance.ChangePassword(Convert.ToString(Request.Form["ctl00$MainContent$uemail"]), Convert.ToString(Request.Form["useroldpass"]), Convert.ToString(Request.Form["usernewpass"]));
                        if(!updated)
                        {
                            Response.Redirect("MyAccount.aspx?status=400", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                        else
                        {
                            Response.Redirect("MyAccount.aspx?status=1", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }
                    else
                    {
                        Response.Redirect("MyAccount.aspx?status=404", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }


                }
                
            }
            else
            {
                Response.Redirect("login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }


        }
    }
}