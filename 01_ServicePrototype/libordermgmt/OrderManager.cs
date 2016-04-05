//#define GOOGLE_SUGGESTER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using libwebsvcprod;
using Microsoft.VisualBasic;

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

        public override bool Equals(object obj)
        {
            CustomerInfo info;
            bool bEquals;

            if (obj.GetType() == typeof(CustomerInfo))
            {
                info = (CustomerInfo)obj;
                bEquals = (CustomerID == info.CustomerID);
                bEquals &= (CompanyName.Equals(info.CompanyName));
                bEquals &= (Address.Equals(info.Address));
                bEquals &= (EMail.Equals(info.EMail));
                bEquals &= (PhoneNumber.Equals(info.PhoneNumber));

                return bEquals;
            }

            return base.Equals(obj);
        }
    }

    public enum ORDERSTATUS
    {
        Placed, Processing, Designed, CustomerOK, Advertising
    }

    public struct OrderInfo
    {
        public int OrderID;
        public CustomerInfo Customer;
        public AdService Service;
        public DateTime OrderDate;
        public ORDERSTATUS OrderStatus;
        public DateTime CompletionDate;

        public override bool Equals(object obj)
        {
            OrderInfo info;
            bool bEquals;

            if (obj.GetType() == typeof(OrderInfo))
            {
                info = (OrderInfo)obj;
                bEquals = (OrderID == info.OrderID);
                bEquals &= (Service.Equals(info.Service));
                bEquals &= (OrderDate == info.OrderDate);
                bEquals &= (OrderStatus == info.OrderStatus);
                bEquals &= (CompletionDate == info.CompletionDate);

                return bEquals;
            }

            return base.Equals(obj);
        }
    }

    public struct AdService
    {
        public int ServiceID;
        public string ServiceName;
        public double Price;

        public override bool Equals(object obj)
        {
            AdService info;
            bool bEquals;

            try
            {
                if (obj.GetType() == typeof(AdService))
                {
                    info = (AdService)obj;
                    bEquals = (ServiceID == info.ServiceID);
                    bEquals &= (ServiceName.Equals(info.ServiceName));
                    bEquals &= (Price == info.Price);

                    return bEquals;
                }
            }
            catch (Exception)
            {
            }

            return base.Equals(obj);
        }
    }

    public struct Product
    {
        public int ProductID;
        public OrderInfo Order;
        public string ProductName;
        public string Description;
        public string TagList;

        public override bool Equals(object obj)
        {
            Product info;
            bool bEquals;

            if (obj.GetType() == typeof(Product))
            {
                info = (Product)obj;
                bEquals = (ProductID == info.ProductID);
                bEquals &= (Order.Equals(info.Order));
                bEquals &= (Description.Equals(info.Description));
                bEquals &= (TagList.Equals(info.TagList));

                return bEquals;
            }

            return base.Equals(obj);
        }
    }

    public struct DesignRequest
    {
        public int RequestID;
        public OrderInfo Order;
        public string DesignDetails;

        public override bool Equals(object obj)
        {
            DesignRequest info;
            bool bEquals;

            if (obj.GetType() == typeof(DesignRequest))
            {
                info = (DesignRequest)obj;
                bEquals = (RequestID == info.RequestID);
                bEquals &= (Order.Equals(info.Order));
                bEquals &= (DesignDetails.Equals(info.DesignDetails));

                return bEquals;
            }

            return base.Equals(obj);
        }
    }

    public struct BusStopInfo
    {
        public string BusStopID;
        public string StationName;
        public string NameKor;
        public string NameEng;
        public List<string> TagsKor;
        public List<string> TagsEng;

        public override bool Equals(object obj)
        {
            BusStopInfo info;
            bool bEquals;

            if (obj.GetType() == typeof(BusStopInfo))
            {
                info = (BusStopInfo)obj;
                bEquals = (BusStopID == info.BusStopID);
                bEquals &= (StationName.Equals(info.StationName));
                bEquals &= (NameKor.Equals(info.NameKor));
                bEquals &= (NameEng.Equals(info.NameEng));
                //bEquals &= (TagsKor.Equals(info.TagsKor));
                //bEquals &= (TagsEng.Equals(info.TagsEng));

                return bEquals;
            }

            return base.Equals(obj);
        }
    }

    public struct AdPlacement
    {
        public OrderInfo Order;
        public BusStopInfo BusStop;
        public DateTime PlacementTime;
    }

    public struct TagInfo
    {
        public string BusStopID;
        public string NameKor;
        public string NameEng;
        public string TagName;

        public override bool Equals(object obj)
        {
            TagInfo info;
            bool bEquals;

            if (obj.GetType() == typeof(TagInfo))
            {
                info = (TagInfo)obj;
                bEquals = (BusStopID == info.BusStopID);
                bEquals &= (NameKor.Equals(info.NameKor));
                bEquals &= (NameEng.Equals(info.NameEng));
                bEquals &= (TagName.Equals(info.TagName));
                //bEquals &= (TagsKor.Equals(info.TagsKor));
                //bEquals &= (TagsEng.Equals(info.TagsEng));

                return bEquals;
            }

            return base.Equals(obj);
        }
    }
    #endregion

    public class OrderManager : DatabaseIO
    {
        public delegate T dReadAction<T>(MySqlDataReader reader);

        dReadAction<CustomerInfo> FUNC_GET_CUSTOMER;
        dReadAction<AdService> FUNC_GET_ADSERVICE;
        dReadAction<OrderInfo> FUNC_GET_ORDER;
        dReadAction<Product> FUNC_GET_PRODUCT;
        dReadAction<TagInfo> FUNC_GET_TAG;

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

            // AdService Table
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS AdService
(
    ServiceID INT NOT NULL AUTO_INCREMENT,
    ServiceName VARCHAR(255),
    Price DECIMAL,
    PRIMARY KEY (ServiceID)
)");
            _cmd.ExecuteNonQuery();

            // Order Table
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS OrderInfo
(
    OrderID INT NOT NULL AUTO_INCREMENT,
    CustomerID INT NOT NULL,
    ServiceID INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    OrderStatus INT NOT NULL,
    CompletionDate DATETIME,
    PRIMARY KEY (OrderID),
    CONSTRAINT FK_OrderInfo_CustomerID FOREIGN KEY (CustomerID)
    REFERENCES Customer(CustomerID),
    CONSTRAINT FK_OrderInfo_ServiceID FOREIGN KEY (ServiceID)
    REFERENCES AdService(ServiceID)
)");
            _cmd.ExecuteNonQuery();

            // Product Table
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS Product
(
    ProductID INT NOT NULL AUTO_INCREMENT,
    OrderID INT NOT NULL,
    ProductName VARCHAR(255),
    Description VARCHAR(255),
    TagList VARCHAR(255),
    PRIMARY KEY (ProductID),
    CONSTRAINT FK_Product_OrderID FOREIGN KEY (OrderID)
    REFERENCES OrderInfo(OrderID)
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
    BusStopID VARCHAR(255) NOT NULL,
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
    BusStopID VARCHAR(255) NOT NULL,
    TagName VARCHAR(255),
    PRIMARY KEY (TagID),
    CONSTRAINT FK_TagList_BusStop_BusStopID FOREIGN KEY (BusStopID)
    REFERENCES BusStop(BusStopID)
)");
            _cmd.ExecuteNonQuery();

            /*// BusStop List
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS TagList_BusStop
(
    TagID INT NOT NULL,
    BusStopID INT NOT NULL,
    CONSTRAINT FK_TagList_BusStop_BusStop_BusStopID FOREIGN KEY (BusStopID)
    REFERENCES BusStop(BusStopID)
)");
            _cmd.ExecuteNonQuery();*/

            // Advertisement Placement
            _cmd.CommandText = String.Format(
@"CREATE TABLE IF NOT EXISTS AdPlacement
(
    OrderID INT NOT NULL,
    BusStopID VARCHAR(255) NOT NULL,
    PlacementTime DATETIME,
    CONSTRAINT FK_AdPlacement_BusStop_OrderID FOREIGN KEY (OrderID)
    REFERENCES OrderInfo(OrderID),
    CONSTRAINT FK_OrderInfo_BusStop_BusStopID FOREIGN KEY (BusStopID)
    REFERENCES BusStop(BusStopID)
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

            // Get AdService
            FUNC_GET_ADSERVICE = new dReadAction<AdService>((reader) =>
            {
                AdService data = new AdService();

                data.ServiceID = reader.GetInt32("ServiceID");
                data.ServiceName = reader.GetString("ServiceName");
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
                
                data.Service = new AdService();
                data.Service.ServiceID = reader.GetInt32("ServiceID");

                data.OrderDate = reader.GetDateTime("OrderDate");
                data.OrderStatus = (ORDERSTATUS)reader.GetInt32("OrderStatus");

                return data;
            });

            // Get Product
            FUNC_GET_PRODUCT = new dReadAction<Product>((reader) =>
            {
                Product data = new Product();

                data.ProductID = reader.GetInt32("ProductID");

                data.Order = new OrderInfo();
                data.Order.OrderID = reader.GetInt32("OrderID");

                data.ProductName = reader.GetString("ProductName");
                data.Description = reader.GetString("Description");
                data.TagList = reader.GetString("TagList");

                return data;
            });
            
            // Get Tag
            FUNC_GET_TAG = new dReadAction<TagInfo>((reader) =>
            {
                TagInfo data = new TagInfo();

                data.BusStopID = reader.GetString("BusStopID");

                data.NameKor = reader.GetString("NameKor");
                data.NameEng = reader.GetString("NameEng");
                data.TagName = reader.GetString("TagName");

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

        private void UpdateData(string query)
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

        private int GetNextIndex(string tableName)
        {
            MySqlDataReader reader;

            _cmd.CommandText = String.Format(
@"SELECT AUTO_INCREMENT
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = '{0}'
AND TABLE_NAME = '{1}'", DATABASE_NAME, tableName);

            using (reader = _cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return reader.GetInt32("AUTO_INCREMENT");
                    }
                }
            }

            return -1;
        }
        #endregion

        #region Insert Functions
        private string ReplaceSQLWord(string word)
        {
            string rtnData;

            rtnData = word.ToLower();
            rtnData = Strings.Replace(rtnData, @"'", @"\'");
            rtnData = Strings.Replace(rtnData, @"\\", @"\");

            return rtnData;
        }

        public int InsertCustomer(CustomerInfo info)
        {
            string query;
            int index;

            index = GetNextIndex("Customer");

            query = String.Format(
@"INSERT INTO Customer (CompanyName, Address, EMail, PhoneNumber)
    VALUES ('{0}', '{1}', '{2}', '{3}')"
            , info.CompanyName, info.Address, info.EMail, info.PhoneNumber);

            InsertData(query);

            return index;
        }

        public int InsertAdService(AdService service)
        {
            string query;
            int index;

            index = GetNextIndex("AdService");

            query = String.Format(
@"INSERT INTO AdService (ServiceName, Price)
    VALUES ('{0}', {1})"
            , service.ServiceName, service.Price);

            InsertData(query);

            return index;
        }

        public int InsertOrder(OrderInfo info)
        {
            string query;
            int index;

            index = GetNextIndex("OrderInfo");

            //12-01-2014 00:00:00
            query = String.Format(
@"INSERT INTO OrderInfo (CustomerID, ServiceID, OrderDate, OrderStatus)
    VALUES ({0}, {1}, STR_TO_DATE('{2}', '{3}'), '{4}')"
            , info.Customer.CustomerID, info.Service.ServiceID,
            SQLDate(info.OrderDate), SQL_DATE_FORMAT, (int)info.OrderStatus);

            InsertData(query);

            return index;
        }

        /*public int InsertOrder(CustomerInfo info, AdService service)
        {
            string query;
            int index;

            index = GetNextIndex("OrderInfo");

            query = String.Format(
@"INSERT INTO OrderInfo (CustomerID, ServiceID, OrderStatus)
    VALUES ({0}, {1}, '{2}')"
            , info.CustomerID, service.ServiceID, (int)ORDERSTATUS.Placed);

            InsertData(query);

            return index;
        }*/

        public int InsertProduct(int orderID, Product product)
        {
            string query;
            int index;

            index = GetNextIndex("Product");

            query = String.Format(
@"INSERT INTO Product (OrderID, ProductName, Description, TagList)
    VALUES ({0}, '{1}', '{2}', '{3}')"
            , orderID, product.ProductName, product.Description, product.TagList);

            InsertData(query);

            return index;
        }

        public void InsertBusStop(BusStopInfo info)
        {
            GoogleSuggester suggester;
            string query;
            string splitWord;
            string[] tagList;

            query = String.Format(
@"INSERT INTO BusStop (BusStopID, NameKor, NameEng)
    VALUES ('{0}', '{1}', '{2}')"
            , info.BusStopID, ReplaceSQLWord(info.NameKor), ReplaceSQLWord(info.NameEng));

            InsertData(query);

#if GOOGLE_SUGGESTER
            char[] delimiters = new[] { ',', ';', ' ', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};  // List of your delimiters
            splitWord = info.NameKor.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)[0];

            suggester = new GoogleSuggester();
            tagList = suggester.GetSuggestionsList(splitWord);

            InsertTagInfo(info, ReplaceSQLWord(info.NameKor));
            InsertTagInfo(info, ReplaceSQLWord(splitWord));

            foreach (string s in tagList)
            {
                if (s != splitWord)
                {
                    InsertTagInfo(info, ReplaceSQLWord(s));
                }
            }

            if (info.NameEng != "")
            {
                splitWord = info.NameEng.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)[0];

                tagList = suggester.GetSuggestionsList(splitWord);

                InsertTagInfo(info, ReplaceSQLWord(info.NameEng));
                InsertTagInfo(info, ReplaceSQLWord(splitWord));

                foreach (string s in tagList)
                {
                    if (s != splitWord)
                    {
                        InsertTagInfo(info, ReplaceSQLWord(s));
                    }
                }
            }
#endif
        }

        public int InsertTagInfo(BusStopInfo info, string tag)
        {
            string query;
            int index;

            index = GetNextIndex("TagList");

            query = String.Format(
@"INSERT INTO TagList (BusStopID, TagName)
VALUES ('{0}', '{1}')
"
            , info.BusStopID, tag);

            InsertData(query);

            return index;
        }
        #endregion

        #region Update Functions
        public void UpdateOrder(OrderInfo info)
        {
            string query;

            //UPDATE table_name
            //SET column1=value, column2=value2,...
            //WHERE some_column=some_value  

            //12-01-2014 00:00:00

            if (info.CompletionDate != DateTime.MinValue)
            {
                query = String.Format(
@"UPDATE OrderInfo
SET OrderStatus={0}, CompletionDate=STR_TO_DATE('{1}', '{2}')
WHERE OrderID={3}"
                , (int)info.OrderStatus, SQLDate(info.CompletionDate), SQL_DATE_FORMAT,
                info.OrderID);
            }
            else
            {
                query = String.Format(
@"UPDATE OrderInfo
SET OrderStatus={0}
WHERE OrderID={1}"
                , (int)info.OrderStatus, info.OrderID);
            }

            UpdateData(query);
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

        public bool FindAdService(string serviceName, ref AdService service)
        {
            string query;

            query = String.Format(
@"SELECT * FROM Customer WHERE UPPER(ServiceName) = '{0}'"
            , serviceName.ToUpper());

            return QueryData<AdService>(query, ref service, FUNC_GET_ADSERVICE);
        }

        public bool FindProduct(int orderID, ref Product product)
        {
            string query;

            query = String.Format(
@"SELECT * FROM Product WHERE OrderID = {0}"
            , orderID);

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

        public AdService GetAdServiceById(int serviceID)
        {
            AdService service;
            string query;

            service = new AdService();

            query = String.Format(
@"SELECT * FROM AdService WHERE ServiceID = {0}"
            , serviceID);

            QueryData<AdService>(query, ref service, FUNC_GET_ADSERVICE);

            return service;
        }
        #endregion

        #region Retrieve List
        public AdService[] RetrieveAdService()
        {
            return RetrieveMultipleData<AdService>("SELECT * FROM AdService", FUNC_GET_ADSERVICE);
        }

        public OrderInfo[] RetrieveOrder()
        {
            OrderInfo[] orderArray;
            orderArray = RetrieveMultipleData<OrderInfo>("SELECT * FROM OrderInfo", FUNC_GET_ORDER);

            for (int i = 0; i < orderArray.Length; i++)
            {
                orderArray[i].Customer = GetCustomerById(orderArray[i].Customer.CustomerID);
                orderArray[i].Service = GetAdServiceById(orderArray[i].Service.ServiceID);
            }

            return orderArray;
        }

        public OrderInfo[] RetrieveOrder(ORDERSTATUS status)
        {
            OrderInfo[] orderArray;
            orderArray = RetrieveMultipleData<OrderInfo>(
                String.Format("SELECT * FROM OrderInfo WHERE OrderStatus >= {0}", (int)status)
                , FUNC_GET_ORDER);

            for (int i = 0; i < orderArray.Length; i++)
            {
                orderArray[i].Customer = GetCustomerById(orderArray[i].Customer.CustomerID);
                orderArray[i].Service = GetAdServiceById(orderArray[i].Service.ServiceID);
            }

            return orderArray;
        }

        public OrderInfo[] RetrieveOrder(CustomerInfo customer)
        {
            OrderInfo[] orderArray;
            orderArray = RetrieveMultipleData<OrderInfo>(
                String.Format("SELECT * FROM OrderInfo WHERE CustomerID = {0}", customer.CustomerID)
                , FUNC_GET_ORDER);

            for (int i = 0; i < orderArray.Length; i++)
            {
                orderArray[i].Customer = GetCustomerById(orderArray[i].Customer.CustomerID);
                orderArray[i].Service = GetAdServiceById(orderArray[i].Service.ServiceID);
            }

            return orderArray;
        }

        public TagInfo[] RetriveTags(string word)
        {
            TagInfo[] tagArray;
            tagArray = RetrieveMultipleData<TagInfo>(
                String.Format(
@"SELECT BusStop.BusStopID, BusStop.NameKor, BusStop.NameEng, TagList.TagName
FROM BusStop, TagList
WHERE BusStop.BusStopID = TagList.BusStopID AND TagList.TagName LIKE '%{0}%'
GROUP BY BusStop.BusStopID", word)
                , FUNC_GET_TAG);

            return tagArray;
        }
        #endregion

    }
}