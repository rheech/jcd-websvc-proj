using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace libordermgmt
{
    // We never work on rainy days, and national holidays!! ==> Web Service
    // Real-time currency exchange rate

    public struct CustomerInfo
    {
        public string CustomerID;
        public string CompanyName;
        public string Address;
        public string EMail;
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
        public OrderManager() : base()
        {
            
        }

        protected override void CreateDatabase(bool resetDB)
        {
            base.CreateDatabase(resetDB);

            //Open();

            // Customer Table
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS Customer
(
    CustomerID INT NOT NULL AUTO_INCREMENT,
    CompanyName VARCHAR(255),
    Address VARCHAR(255),
    EMail VARCHAR(255),
    PhoneNumber VARCHAR(255),
    PRIMARY KEY (CustomerID)
)");
            _cmd.ExecuteNonQuery();

            // Product Table
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS Product
(
    ProductID INT NOT NULL AUTO_INCREMENT,
    ProductName VARCHAR(255),
    Price DECIMAL,
    PRIMARY KEY (ProductID)
)");
            _cmd.ExecuteNonQuery();

            // Order Table
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS OrderInfo
(
    OrderID INT NOT NULL AUTO_INCREMENT,
    CustomerID INT NOT NULL,
    OrderStatus VARCHAR(255),
    PRIMARY KEY (OrderID),
    CONSTRAINT FK_OrderInfo_CustomerID FOREIGN KEY (CustomerID)
    REFERENCES Customer(CustomerID)
)");
            _cmd.ExecuteNonQuery();

            // Product_Order Table
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS Product_Order
(
    ProductID INT NOT NULL,
    OrderID INT NOT NULL,
    CONSTRAINT FK_ProductOrder_ProductID FOREIGN KEY (ProductID)
    REFERENCES Product(ProductID),
    CONSTRAINT FK_ProductOrder_OrderID FOREIGN KEY (OrderID)
    REFERENCES OrderInfo(OrderID)
)");
            _cmd.ExecuteNonQuery();

            //Close();
        }

        public void CreateCustomer(CustomerInfo info)
        {
            /*
            @"CREATE TABLE IF NOT EXISTS Customer
            (
                CustomerID INT NOT NULL,
                CompanyName VARCHAR(255),
                Address VARCHAR(255),
                EMail VARCHAR(255),
                PhoneNumber VARCHAR(255),
                CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID)
            )");
            */
            _cmd.CommandText = String.Format(
@"INSERT INTO Customer (CompanyName, Address, EMail, PhoneNumber)
    VALUES ('{0}', '{1}', '{2}', '{3}')
"
            , info.CompanyName, info.Address, info.EMail, info.PhoneNumber);

            _cmd.ExecuteNonQuery();
        }

        public void FindCustomer(CustomerInfo info)
        {
            MySqlDataReader reader;

            _cmd.CommandText = String.Format(
@"SELECT * FROM Customer WHERE EMail = '{0}'"
            , info.EMail);

            reader = _cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
                        reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
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
