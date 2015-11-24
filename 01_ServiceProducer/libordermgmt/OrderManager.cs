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
        public int CustomerID;
        public string CompanyName;
        public string Address;
        public string EMail;
        public string PhoneNumber;
    }

    public struct OrderInfo
    {
        public int OrderID;
        public Product Product;
        public string OrderStatus;
        public CustomerInfo Customer;
    }

    public struct Product
    {
        public int ProductID;
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
    ProductID INT NOT NULL,
    OrderStatus VARCHAR(255),
    PRIMARY KEY (OrderID),
    CONSTRAINT FK_OrderInfo_CustomerID FOREIGN KEY (CustomerID)
    REFERENCES Customer(CustomerID),
    CONSTRAINT FK_OrderInfo_ProductID FOREIGN KEY (ProductID)
    REFERENCEs Product(ProductID)
)");
            _cmd.ExecuteNonQuery();

            /*// Product_Order Table
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
            _cmd.ExecuteNonQuery();*/

            //Close();
        }

        public void InsertCustomer(CustomerInfo info)
        {
            _cmd.CommandText = String.Format(
@"INSERT INTO Customer (CompanyName, Address, EMail, PhoneNumber)
    VALUES ('{0}', '{1}', '{2}', '{3}')
"
            , info.CompanyName, info.Address, info.EMail, info.PhoneNumber);

            _cmd.ExecuteNonQuery();
        }

        public bool FindCustomer(string email, ref CustomerInfo info)
        {
            bool bFound;
            MySqlDataReader reader;

            info = new CustomerInfo();

            _cmd.CommandText = String.Format(
@"SELECT * FROM Customer WHERE UPPER(EMail) = '{0}'"
            , email.ToUpper());

            using (reader = _cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        info.CustomerID = reader.GetInt32("CustomerID");
                        info.CompanyName = reader.GetString("CompanyName");
                        info.Address = reader.GetString("Address");
                        info.EMail = reader.GetString("EMail");
                        info.PhoneNumber = reader.GetString("PhoneNumber");
                    }

                    bFound = true;
                }
                else
                {
                    // No rows found.
                    bFound = false;
                }
            }

            return bFound;
        }

        public CustomerInfo GetCustomerById(int customerID)
        {
            MySqlDataReader reader;
            CustomerInfo info;

            info = new CustomerInfo();

            _cmd.CommandText = String.Format(
@"SELECT * FROM Customer WHERE CustomerID = {0}"
            , customerID);

            using (reader = _cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        info.CustomerID = reader.GetInt32("CustomerID");
                        info.CompanyName = reader.GetString("CompanyName");
                        info.Address = reader.GetString("Address");
                        info.EMail = reader.GetString("EMail");
                        info.PhoneNumber = reader.GetString("PhoneNumber");
                    }
                }
            }

            return info;
        }

        public void InsertProduct(Product product)
        {
            /*@"CREATE TABLE IF NOT EXISTS Product
            (
                ProductID INT NOT NULL AUTO_INCREMENT,
                ProductName VARCHAR(255),
                Price DECIMAL,
                PRIMARY KEY (ProductID)
            )"*/
            _cmd.CommandText = String.Format(
@"INSERT INTO Product (ProductName, Price)
    VALUES ('{0}', {1})
"
            , product.ProductName, product.Price);

            _cmd.ExecuteNonQuery();
        }

        public bool FindProduct(string productName, ref Product product)
        {
            bool bFound;
            MySqlDataReader reader;

            product = new Product();

            _cmd.CommandText = String.Format(
@"SELECT * FROM Customer WHERE UPPER(ProductName) = '{0}'"
            , productName.ToUpper());

            using (reader = _cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product.ProductName = reader.GetString("ProductName");
                        product.Price = reader.GetDouble("Price");
                    }

                    bFound = true;
                }
                else
                {
                    // No rows found.
                    bFound = false;
                }
            }

            return bFound;
        }

        public Product[] RetrieveProduct()
        {
            MySqlDataReader reader;
            List<Product> productList;
            Product product;

            productList = new List<Product>();
            _cmd.CommandText = @"SELECT * FROM Product";

            using (reader = _cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product = new Product();
                        product.ProductID = reader.GetInt32("ProductID");
                        product.ProductName = reader.GetString("ProductName");
                        product.Price = reader.GetDouble("Price");

                        productList.Add(product);
                    }
                }
            }

            return productList.ToArray();
        }

        public Product GetProductById(int productID)
        {
            MySqlDataReader reader;
            Product product;

            product = new Product();

            _cmd.CommandText = String.Format(
@"SELECT * FROM Product WHERE ProductID = {0}"
            , productID);

            using (reader = _cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product.ProductID = reader.GetInt32("ProductID");
                        product.ProductName = reader.GetString("ProductName");
                        product.Price = reader.GetDouble("Price");
                    }
                }
            }

            return product;
        }

        public void InsertOrder(CustomerInfo info, Product product)
        {
            // Return Order info as an invoice
            // Send email for order confirmation
/*@"CREATE TABLE IF NOT EXISTS OrderInfo
(
    OrderID INT NOT NULL AUTO_INCREMENT,
    CustomerID INT NOT NULL,
    OrderStatus VARCHAR(255),
    PRIMARY KEY (OrderID),
    CONSTRAINT FK_OrderInfo_CustomerID FOREIGN KEY (CustomerID)
    REFERENCES Customer(CustomerID)
)"*/
            _cmd.CommandText = String.Format(
@"INSERT INTO OrderInfo (CustomerID, ProductID, OrderStatus)
    VALUES ({0}, {1}, '{2}')
"
            , info.CustomerID, product.ProductID, "Placed");

            _cmd.ExecuteNonQuery();
        }

        public OrderInfo[] RetrieveOrder()
        {
            MySqlDataReader reader;
            List<OrderInfo> orderList;
            OrderInfo[] orderArray;
            OrderInfo info;

            orderList = new List<OrderInfo>();
            _cmd.CommandText = @"SELECT * FROM OrderInfo";

            using (reader = _cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        info = new OrderInfo();
                        info.OrderID = reader.GetInt32("OrderID");

                        info.Customer = new CustomerInfo();
                        info.Customer.CustomerID = reader.GetInt32("CustomerID");

                        info.Product = new Product();
                        info.Product.ProductID = reader.GetInt32("ProductID");
                        info.OrderStatus = reader.GetString("OrderStatus");

                        orderList.Add(info);
                    }
                }
            }

            orderArray = orderList.ToArray();

            for (int i = 0; i < orderArray.Length; i++)
            {
                orderArray[i].Customer = GetCustomerById(orderArray[i].Customer.CustomerID);
                orderArray[i].Product = GetProductById(orderArray[i].Product.ProductID);
            }

            return orderArray;
        }
    }
}
