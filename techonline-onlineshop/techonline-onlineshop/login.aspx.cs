using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace techonline_onlineshop
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
         protected void Reg_Click(object sender, EventArgs e)
        {
            Response.Redirect("registration.aspx");
        }
        protected void LoginSing_Click(object sender, EventArgs e)
        {
           string email = "", pass = "";
            email = LoginSing.Text;
            pass = Loginpassword.Text;

        }
    }
}