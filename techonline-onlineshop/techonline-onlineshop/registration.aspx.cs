using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace techonline_onlineshop
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
            string name = fnameid.Text;
            string lname = lnameid.Text;
            string email = emailid.Text;
            string pass = passid.Text;
            SqlConnection con = new SqlConnection("Data Source=ANDREJNANKOV;Initial Catalog=db_techonlineGNML;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO Table (name, lastname, pass, email) VALUES ('@name','@lastname','@pass','@email');";
            cmd.Connection = con;
            con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while(read.Read())
                {
                    cmd.Parameters.AddWithValue("@name",name);
                    cmd.Parameters.AddWithValue("@lastname",lname);
                    cmd.Parameters.AddWithValue("@pass",pass);
                    cmd.Parameters.AddWithValue("@email",email);
                }
            con.Close();
        }
    }
}