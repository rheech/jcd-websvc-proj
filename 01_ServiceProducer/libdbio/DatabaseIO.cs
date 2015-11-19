using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace libdbio
{
    public class DatabaseIO
    {
        const string BASE_PATH = "D:\\Programs\\iis_webpage\\dbtemp\\";
        const string MDB_PATH = "D:\\Programs\\iis_webpage\\dbtemp\\servicedata.mdb";

        FileInfo _file;
        OleDbConnection _con;

        private DatabaseIO(string fileName)
        {
            // for security, remove invalid characters and limit file name to 10
            fileName = Regex.Replace(fileName, "[^0-9a-zA-Z_.-]+", "");
            fileName = fileName.Substring(0, 30);

            _file = new FileInfo(String.Format("{0}{1}", BASE_PATH, fileName));

            if (!_file.Exists)
            {
                Create();
            }
        }

        public DatabaseIO()
        {
            _file = new FileInfo(MDB_PATH);

            if (!_file.Exists)
            {
                Create();
            }
        }

        public void Reset()
        {
            if (_file.Exists)
            {
                _file.Delete();
            }

            Create();
        }

        private void Create()
        {
            ADOX.Catalog cat;
            OleDbConnection con;
            OleDbCommand oCmd;

            // Create MDB
            cat = new ADOX.Catalog();
            cat.Create(ConnectionString);

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

        public void Open()
        {
            _con = new OleDbConnection(ConnectionString);
            _con.Open();
        }

        public void Close()
        {
            if (_con != null)
            {
                _con.Close();
            }
            else
            {
                throw new Exception("Database is not open.");
            }
        }

        private string ConnectionString
        {
            get
            {
                return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\"", _file.FullName);
            }
        }
    }
}
