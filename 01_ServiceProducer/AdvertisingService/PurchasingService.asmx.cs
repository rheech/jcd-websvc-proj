using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using libordermgmt;

namespace AdvertisingService
{
    /// <summary>
    /// Summary description for PurchasingService
    /// </summary>
    [WebService(Namespace = "http://lab.cheonghyun.com:8888/AdvertisingService/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PurchasingService : System.Web.Services.WebService
    {
        [WebMethod]
        public void SendOrderDetails()
        {
            
        }

        [WebMethod]
        public string RequestOrder(OrderInfo info)
        {
            return info.Requirement;
        }

        [WebMethod]
        public string CheckOrderStatus(OrderInfo info)
        {
            return info.Requirement;
        }
    }
}
