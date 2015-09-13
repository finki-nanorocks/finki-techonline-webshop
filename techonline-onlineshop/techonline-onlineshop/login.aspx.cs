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
        protected void LoginSing_Click(object sender, EventArgs e)
        {
            string email = LoginSing.Text;
            string pass = Loginpassword.Text;
            TechonlineAPI.Database d = new TechonlineAPI.Database();
            string tmp = d.checkUser(email, pass);
            if(tmp != "")
            Response.Redirect("~/home.aspx");
            else { Response.Redirect("~/shop.aspx"); }
            
        }
    }
}