using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libdbio
{
    // We never work on rainy days, and national holidays!! ==> Web Service

    public struct CustomerInfo
    {
        public string CustomerID;
        public string CompanyName;
        public string Address;
        public string PhoneNumber;
    }

    public struct OrderInfo
    {
        public string OrderID;
        public string OrderStatus;
        public CustomerInfo Customer;
        public string Requirement;
    }

    public struct Product
    {
        public string ProductID;
        public string ProductName;
        public double Price;
    }

    public class OrderManager : DatabaseIO
    {
        public OrderManager(string dbFileName) : base()
        {

        }

        public void CreateCustomer(CustomerInfo info)
        {
        }

        public void FindCustomer(CustomerInfo info)
        {
        }

        public void CustomerExists(CustomerInfo info)
        {
        }

        public void FindProduct(Product product)
        {
        }

        public void CreateOrder(CustomerInfo info, Product product)
        {
            // Return Order info as an invoice
            // Send email for order confirmation
        }

        public void RetrieveOrder(OrderInfo info)
        {
        }
    }
}
