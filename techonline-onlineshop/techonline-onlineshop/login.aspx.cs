using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;


namespace TechonlineFrontend
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = "";

            if(IsPostBack)
            {

                if(!string.IsNullOrWhiteSpace( Request["loginemail"]) && !string.IsNullOrWhiteSpace(Request["loginpassword"]))
                {
                    String email = Request["loginemail"];
                    String password = Request["loginpassword"];

                    if(TOS.Instance.canLogin(email, password))
                    {
                        TOSession.Current.user = TOS.Instance.getUser(email);
                        Response.Redirect("home.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        Response.Redirect("login.aspx?loginfail=true", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }

                }
            }
            else
            {
                if(!string.IsNullOrWhiteSpace(Request["loginfail"]) && string.Equals(Request["loginfail"], "true"))
                {
                    actionStatus.Attributes["class"] = "alert alert-danger";
                    actionStatus.InnerHtml = "<strong>Error!</strong> Wrong credentials. Please try again.";
                }
            }

        }
         protected void Reg_Click(object sender, EventArgs e)
        {
            //Avoid 'System.Threading.ThreadAbortException'
            Response.Redirect("registration.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        protected void LoginSing_Click(object sender, EventArgs e)
        {


        }
    }
}