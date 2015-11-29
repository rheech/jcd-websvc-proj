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
        OrderManager _om;

        public PurchasingService()
        {
            _om = new OrderManager();
        }

        [WebMethod]
        public void CreateOrder(CustomerInfo info, Product product)
        {
            _om.InsertOrder(info, product);
        }

        [WebMethod]
        public Product[] RetrieveProduct()
        {
            return _om.RetrieveProduct();
        }

        [WebMethod]
        public bool FindCustomer(string email, ref CustomerInfo info)
        {
            return _om.FindCustomer(email, ref info);
        }

        [WebMethod]
        public void SendOrderDetails()
        {
            
        }

        [WebMethod]
        public string RequestOrder(OrderInfo info)
        {
            return "Succeed2";
        }

        [WebMethod]
        public string CheckOrderStatus(OrderInfo info)
        {
            return "Succeed";
        }
    }
}
