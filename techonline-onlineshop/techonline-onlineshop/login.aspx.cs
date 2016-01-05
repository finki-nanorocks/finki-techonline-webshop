using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechonlineAPI;


namespace techonline_onlineshop
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }
         protected void Reg_Click(object sender, EventArgs e)
        {
            Response.Redirect("registration.aspx");
        }
        protected void LoginSing_Click(object sender, EventArgs e)
        {
            string email,pass;
            email = LoginSing.Text;
            pass = Loginpassword.Text;
            Database d = new Database();
            string korisnik = d.checkUser(email, pass);
            if(korisnik == "")
            {
                TextBox1.Text = "Nepostoi takov korisnik";//treba da se proveri neso ne presmetue dobro!!!
            }
            else
            {
                Session["korisnicko_ime"] = korisnik;
                TextBox1.Text = "postoi";
            }
        }
    }
}