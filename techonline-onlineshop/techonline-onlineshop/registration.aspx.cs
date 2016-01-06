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