using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TechonlineAPI;

namespace techonline_onlineshop
{
    /// <summary>
    /// Summary description for servis_korisnik
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class servis_korisnik : System.Web.Services.WebService
    {




        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int NumberOfClientsInBase()
        {
            Database d = new Database();
            return d.get_len_client();
        }
        [WebMethod]
        public int NumberOfArticlesInBase()
        {
            Database d = new Database();
            return d.get_len_article();
        }
    }
}
