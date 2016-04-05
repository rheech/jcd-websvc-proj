using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using libordermgmt;

namespace AdvertisingService
{
    /// <summary>
    /// Summary description for OrderManagerService
    /// </summary>
    [WebService(Namespace = "http://lab.cheonghyun.com:8888/AdvertisingService/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OrderManagerService : System.Web.Services.WebService
    {
        OrderManager _om;

        public OrderManagerService()
        {
            _om = new OrderManager();
        }

        [WebMethod]
        public void InsertCustomer(CustomerInfo info)
        {
            _om.InsertCustomer(info);
        }

        [WebMethod]
        public bool FindCustomer(string email, ref CustomerInfo info)
        {
            return _om.FindCustomer(email, ref info);
        }

        [WebMethod]
        public CustomerInfo GetCustomerById(int customerID)
        {
            return _om.GetCustomerById(customerID);
        }

        [WebMethod]
        public void InsertProduct(AdService product)
        {
            _om.InsertAdService(product);
        }

        [WebMethod]
        public bool FindProduct(string productName, ref AdService product)
        {
            return _om.FindAdService(productName, ref product);
        }

        [WebMethod]
        public AdService[] RetrieveProduct()
        {
            return _om.RetrieveAdService();
        }

        [WebMethod]
        public AdService GetAdServiceById(int productID)
        {
            return _om.GetAdServiceById(productID);
        }

        [WebMethod]
        public void InsertOrder(CustomerInfo info, AdService product)
        {
            _om.InsertOrder(info, product);
        }

        [WebMethod]
        public OrderInfo[] RetrieveOrder()
        {
            return _om.RetrieveOrder();
        }
    }
}
