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
    // Return Order info as an invoice
    // Send email for order confirmation

    #region Data Structure
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

    public struct DesignRequest
    {
        public int RequestID;
        public OrderInfo Order;
        public string DesignDetails;
    }

    public struct BusStopInfo
    {
        public int BusStopID;
        public string StationID;
        public string StationName;
        public string NameKor;
        public string NameEng;
        public List<string> TagsKor;
        public List<string> TagsEng;
    }

    public struct AdPlacement
    {
        public OrderInfo Order;
        public BusStopInfo BusStop;
        public DateTime PlacementTime;
    }
    #endregion

    public class OrderManager : DatabaseIO
    {
        public delegate T dReadAction<T>(MySqlDataReader reader);

        dReadAction<CustomerInfo> FUNC_GET_CUSTOMER;
        dReadAction<Product> FUNC_GET_PRODUCT;
        dReadAction<OrderInfo> FUNC_GET_ORDER;

        public OrderManager() : base()
        {
            SetDataRetrieveFunc();
        }

        #region Initial Task
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
    OrderDate DATETIME,
    OrderStatus VARCHAR(255),
    CompletionDate DATETIME,
    Description VARCHAR(255),
    TagInfo VARCHAR(255),
    PRIMARY KEY (OrderID),
    CONSTRAINT FK_OrderInfo_CustomerID FOREIGN KEY (CustomerID)
    REFERENCES Customer(CustomerID),
    CONSTRAINT FK_OrderInfo_ProductID FOREIGN KEY (ProductID)
    REFERENCEs Product(ProductID)
)");
            _cmd.ExecuteNonQuery();

            // Design Request Table
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS DesignRequest
(
    RequestID INT NOT NULL AUTO_INCREMENT,
    OrderID INT NOT NULL,
    DesignDetails VARCHAR(255),
    PRIMARY KEY (RequestID),
    CONSTRAINT FK_DesignRequest_OrderID FOREIGN KEY (OrderID)
    REFERENCES OrderInfo(OrderID)
)");
            _cmd.ExecuteNonQuery();

            // Bus Stop Table
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS BusStop
(
    BusStopID INT NOT NULL AUTO_INCREMENT,
    StationID VARCHAR(255) NOT NULL,
    NameKor VARCHAR(255) NOT NULL,
    NameEng VARCHAR(255),
    PRIMARY KEY (BusStopID)
)");
            _cmd.ExecuteNonQuery();

            // Tag List
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS TagList
(
    TagID INT NOT NULL AUTO_INCREMENT,
    TagNameKor VARCHAR(255),
    TagNameEng VARCHAR(255),
    PRIMARY KEY (TagID)
)");
            _cmd.ExecuteNonQuery();

            // BusStop List
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS TagList_BusStop
(
    TagID INT NOT NULL,
    BusStopID INT NOT NULL,
    CONSTRAINT FK_TagList_BusStop_BusStop_BusStopID FOREIGN KEY (BusStopID)
    REFERENCEs BusStop(BusStopID)
)");
            _cmd.ExecuteNonQuery();

            // Advertisement Placement
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS AdPlacement
(
    OrderID INT NOT NULL,
    BusStopID INT NOT NULL,
    PlacementTime DATETIME,
    CONSTRAINT FK_AdPlacement_BusStop_OrderID FOREIGN KEY (OrderID)
    REFERENCES OrderInfo(OrderID),
    CONSTRAINT FK_OrderInfo_BusStop_BusStopID FOREIGN KEY (BusStopID)
    REFERENCEs BusStop(BusStopID)
)");
            _cmd.ExecuteNonQuery();
        }

        protected void SetDataRetrieveFunc()
        {
            // Get CustomerInfo
            FUNC_GET_CUSTOMER = new dReadAction<CustomerInfo>((reader) =>
            {
                CustomerInfo data = new CustomerInfo();

                data.CustomerID = reader.GetInt32("CustomerID");
                data.CompanyName = reader.GetString("CompanyName");
                data.Address = reader.GetString("Address");
                data.EMail = reader.GetString("EMail");
                data.PhoneNumber = reader.GetString("PhoneNumber");

                return data;
            });

            // Get Product
            FUNC_GET_PRODUCT = new dReadAction<Product>((reader) =>
            {
                Product data = new Product();

                data.ProductID = reader.GetInt32("ProductID");
                data.ProductName = reader.GetString("ProductName");
                data.Price = reader.GetDouble("Price");

                return data;
            });

            // Get OrderInfo
            FUNC_GET_ORDER = new dReadAction<OrderInfo>((reader) =>
            {
                OrderInfo data = new OrderInfo();

                data.OrderID = reader.GetInt32("OrderID");

                data.Customer = new CustomerInfo();
                data.Customer.CustomerID = reader.GetInt32("CustomerID");

                data.Product = new Product();
                data.Product.ProductID = reader.GetInt32("ProductID");
                data.OrderStatus = reader.GetString("OrderStatus");

                return data;
            });
        }
        #endregion

        #region Generic Functions
        private void InsertData(string query)
        {
            _cmd.CommandText = query;
            _cmd.ExecuteNonQuery();
        }

        private bool QueryData<T>(string query, ref T info, dReadAction<T> readAction)
        {
            MySqlDataReader reader;

            _cmd.CommandText = query;

            using (reader = _cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        info = (T)readAction(reader);
                    }

                    return true;
                }
                else
                {
                    // No rows found.
                    return false;
                }
            }
        }

        private T[] RetrieveMultipleData<T>(string query, dReadAction<T> readAction)
        {
            MySqlDataReader reader;
            List<T> dataList;
            T data;

            dataList = new List<T>();
            _cmd.CommandText = query;

            using (reader = _cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data = (T)readAction(reader);
                        dataList.Add(data);
                    }
                }
            }

            return dataList.ToArray();
        }
        #endregion

        #region Insert Functions
        public void InsertCustomer(CustomerInfo info)
        {
            string query;

            query = String.Format(
@"INSERT INTO Customer (CompanyName, Address, EMail, PhoneNumber)
    VALUES ('{0}', '{1}', '{2}', '{3}')
"
            , info.CompanyName, info.Address, info.EMail, info.PhoneNumber);

            InsertData(query);
        }

        public void InsertProduct(Product product)
        {
            string query;

            query = String.Format(
@"INSERT INTO Product (ProductName, Price)
    VALUES ('{0}', {1})
"
            , product.ProductName, product.Price);

            InsertData(query);
        }

        public void InsertOrder(CustomerInfo info, Product product)
        {
            string query;

            query = String.Format(
@"INSERT INTO OrderInfo (CustomerID, ProductID, OrderStatus)
    VALUES ({0}, {1}, '{2}')
"
            , info.CustomerID, product.ProductID, "Placed");

            InsertData(query);
        }

        public void InsertBusStop(BusStopInfo info)
        {
            string query;

            query = String.Format(
@"INSERT INTO BusStop (StationID, NameKor, NameEng)
    VALUES ('{0}', '{1}', '{2}')
"
            , info.StationID, info.NameKor, info.NameEng);

            InsertData(query);
        }
        #endregion

        #region Find Functions
        public bool FindCustomer(string email, ref CustomerInfo info)
        {
            string query;

            query = String.Format(
@"SELECT * FROM Customer WHERE UPPER(EMail) = '{0}'"
            , email.ToUpper());

            return QueryData<CustomerInfo>(query, ref info, FUNC_GET_CUSTOMER);
        }

        public bool FindProduct(string productName, ref Product product)
        {
            string query;

            query = String.Format(
@"SELECT * FROM Customer WHERE UPPER(ProductName) = '{0}'"
            , productName.ToUpper());

            return QueryData<Product>(query, ref product, FUNC_GET_PRODUCT);
        }
        #endregion

        #region Retrieve Data by ID
        public CustomerInfo GetCustomerById(int customerID)
        {
            CustomerInfo info;
            string query;

            info = new CustomerInfo();

            query = String.Format(
@"SELECT * FROM Customer WHERE CustomerID = {0}"
            , customerID);

            QueryData<CustomerInfo>(query, ref info, FUNC_GET_CUSTOMER);

            return info;
        }

        public Product GetProductById(int productID)
        {
            Product product;
            string query;

            product = new Product();

            query = String.Format(
@"SELECT * FROM Product WHERE ProductID = {0}"
            , productID);

            QueryData<Product>(query, ref product, FUNC_GET_PRODUCT);

            return product;
        }
        #endregion

        #region Retrieve List
        public Product[] RetrieveProduct()
        {
            return RetrieveMultipleData<Product>("SELECT * FROM Product", FUNC_GET_PRODUCT);
        }

        public OrderInfo[] RetrieveOrder()
        {
            OrderInfo[] orderArray;
            orderArray = RetrieveMultipleData<OrderInfo>("SELECT * FROM OrderInfo", FUNC_GET_ORDER);

            for (int i = 0; i < orderArray.Length; i++)
            {
                orderArray[i].Customer = GetCustomerById(orderArray[i].Customer.CustomerID);
                orderArray[i].Product = GetProductById(orderArray[i].Product.ProductID);
            }

            return orderArray;
        }
        #endregion

    }
}