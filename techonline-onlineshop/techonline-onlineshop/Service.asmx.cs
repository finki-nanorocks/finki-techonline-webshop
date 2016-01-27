using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TechonlineFrontend
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://techonline.us")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        [WebMethod]
        public List<TechonlineAPI.Product> GetProducts()
        {
            return TechonlineAPI.TOS.Instance.getProducts(-1);
        }

        [WebMethod]
        public List<TechonlineAPI.Brand> GetBrands()
        {
            return TechonlineAPI.TOS.Instance.getAllBrands();
        }

        [WebMethod]
        public TechonlineAPI.User GetUser(string email)
        {
            return TechonlineAPI.TOS.Instance.getUser(email);
        }       
           
    }
}
