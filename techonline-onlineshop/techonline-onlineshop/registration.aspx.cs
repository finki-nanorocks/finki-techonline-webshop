using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using TechonlineAPI;


namespace TechonlineFrontend
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //If user is logged in, no need for registration
            if(TOSession.Current.user != null)
            {
                Response.Redirect("home.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }

            //If post request
            if(IsPostBack)
            {
                bool valid = true;

                //Check if all fields are filled in
                if(string.IsNullOrWhiteSpace(Request["regfirstname"]) || string.IsNullOrWhiteSpace(Request["reglastname"]) 
                    || string.IsNullOrWhiteSpace(Request["regemail"])
                    || string.IsNullOrWhiteSpace(Request["regpass"]) ) { valid = false; }


                if( valid )
                {
                    //Validate for email
                    if (! TOS.Instance.IsValidEmail(Request["regemail"] ) )
                    {
                        valid = false;
                    }

                    //Validate password
                    if (Convert.ToString(Request["regpass"]).Length < 6)
                    {
                        valid = false;
                    }
                }


                //Everything valid. Go on
                if (valid)
                {
                    if (!TOS.Instance.isUserRegistred(Convert.ToString(Request["regemail"])))
                    {
                        TOS.Instance.Debug("HERE HERE HERE");
                        bool registrationStatus = TOS.Instance.register(
                            Convert.ToString(Request["regfirstname"]),
                            Convert.ToString(Request["reglastname"]),
                            Convert.ToString(Request["regemail"]),
                            Convert.ToString(Request["regpass"]),
                            "regular"
                        );

                        if (registrationStatus)
                        {
                            Response.Redirect("registration.aspx?action=success", false);
                            Context.ApplicationInstance.CompleteRequest();
                        }
                    }
                    else
                    {
                        Response.Redirect("registration.aspx?action=exists", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }

                }
                else
                {
                    Response.Redirect("registration.aspx?action=danger", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }

            //Get requests
            if (!string.IsNullOrWhiteSpace(Request.QueryString["action"]) && string.Equals(Request.QueryString["action"], "success"))
            {
                actionStatus.Attributes["class"] = "alert alert-success";
                actionStatus.InnerHtml = "<strong>Success!</strong> Successful Registration! You can login now <a href='/login.aspx'>here</a>";
            }

            if (!string.IsNullOrWhiteSpace(Request.QueryString["action"]) && string.Equals(Request.QueryString["action"], "danger"))
            {
                actionStatus.Attributes["class"] = "alert alert-danger";
                actionStatus.InnerHtml = "<strong>Error!</strong> Please check your form again. Valid password with over 6 characters and email are required.";
            }

            if (!string.IsNullOrWhiteSpace(Request.QueryString["action"]) && string.Equals(Request.QueryString["action"], "exists"))
            {
                actionStatus.Attributes["class"] = "alert alert-danger";
                actionStatus.InnerHtml = "<strong>Error!</strong> Account with that email already exits.";
            }

        }
        protected void Log_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");

        }
        protected void Registerid_Click(object sender, EventArgs e)
        {

        }
    }
}