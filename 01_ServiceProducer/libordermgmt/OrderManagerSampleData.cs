using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libordermgmt
{
    public class OrderManagerSampleData : OrderManager
    {
        public OrderManagerSampleData() : base()
        {
            this.Reset();

            CustomerInfo info = new CustomerInfo();
            info.CompanyName = "White House";
            info.Address = "1600 Pennsylvania Ave NW, Washington, DC 20500";
            info.EMail = "sample@email.com";
            
            this.InsertCustomer(info);

            info = new CustomerInfo();
            info.CompanyName = "KAIST";
            info.Address = "291 Daehak-ro, Yuseong-gu, Daejeon, South Korea";
            info.EMail = "kaist@emailsample.com";

            this.InsertCustomer(info);

            Product product = new Product();
            product.ProductName = "Lightable Ad";
            product.Price = 20000;

            this.InsertProduct(product);
        }
    }
}
