using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace libordermgmt
{
    // We never work on rainy days, and national holidays!! ==> Web Service
    // Real-time currency exchange rate

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
        const string BASE_PATH = "D:\\Programs\\iis_webpage\\dbtemp\\";
        const string MDB_PATH = "D:\\Programs\\iis_webpage\\dbtemp\\servicedata.mdb";

        public OrderManager() : base(MDB_PATH)
        {
            
        }

        protected override void CreateDatabase()
        {
            OleDbConnection con;
            OleDbCommand oCmd;

            base.CreateDatabase();

            // Connect MDB
            con = new OleDbConnection();
            con.ConnectionString = ConnectionString;
            con.Open();

            // Create basic table
            oCmd = new OleDbCommand();
            oCmd.Connection = con;

            // Customer Table
            oCmd.CommandText = String.Format(
@"CREATE TABLE Customer
(
    CustomerID INT NOT NULL,
    CompanyName VARCHAR(255),
    Address VARCHAR(255),
    EMail VARCHAR(255),
    PhoneNumber VARCHAR(255),
    CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID)
)");
            oCmd.ExecuteNonQuery();

            // Product Table
            oCmd.CommandText = String.Format(
@"CREATE TABLE Product
(
    ProductID INT NOT NULL,
    ProductName VARCHAR(255),
    Price CURRENCY,
    CONSTRAINT PK_ProductID PRIMARY KEY (ProductID)
)");
            oCmd.ExecuteNonQuery();

            // Order Table
            oCmd.CommandText = String.Format(
@"CREATE TABLE OrderInfo
(
    OrderID INT NOT NULL,
    CustomerID INT NOT NULL,
    OrderStatus VARCHAR(255),
    CONSTRAINT PK_OrderID PRIMARY KEY (OrderID),
    CONSTRAINT FK_OrderInfo_CustomerID FOREIGN KEY (CustomerID)
    REFERENCES Customer(CustomerID)
)");
            oCmd.ExecuteNonQuery();

            // Product_Order Table
            oCmd.CommandText = String.Format(
@"CREATE TABLE Product_Order
(
    ProductID INT NOT NULL,
    OrderID INT NOT NULL,
    CONSTRAINT FK_ProductOrder_ProductID FOREIGN KEY (ProductID)
    REFERENCES Product(ProductID),
    CONSTRAINT FK_ProductOrder_OrderID FOREIGN KEY (OrderID)
    REFERENCES OrderInfo(OrderID)
)");
            oCmd.ExecuteNonQuery();

            con.Close();
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
