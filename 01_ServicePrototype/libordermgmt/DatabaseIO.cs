using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace libordermgmt
{
    public abstract class DatabaseIO
    {
        protected const string DATABASE_NAME = "advertising_company";

        protected MySqlConnection _con;
        protected MySqlCommand _cmd;
        private bool _isOpen;

        protected const string SQL_DATE_FORMAT = "%m-%d-%Y %H:%i:%s";

        protected DatabaseIO()
        {
            // for security, remove invalid characters and limit file name to 10
            //fileName = Regex.Replace(fileName, "[^0-9a-zA-Z_.-]+", "");
            //fileName = fileName.Substring(0, 30);

            //_file = new FileInfo(String.Format("{0}{1}", BASE_PATH, fileName));
            Open();
            CreateDatabase(false);
        }

        /*public DatabaseIO()
        {
            _file = new FileInfo(MDB_PATH);

            if (!_file.Exists)
            {
                CreateDatabase();
            }
        }*/

        ~DatabaseIO()
        {
            Close();
        }

        public void Reset()
        {
            CreateDatabase(true);
        }

        protected virtual void CreateDatabase(bool resetDB)
        {
            // Connect
            //Open();

            // Create Database
            if (resetDB)
            {
                _cmd.CommandText = String.Format("DROP DATABASE IF EXISTS {0};", DATABASE_NAME);
                _cmd.ExecuteNonQuery();
            }
            
            _cmd.CommandText = String.Format(
@"CREATE DATABASE IF NOT EXISTS {0}
    DEFAULT CHARACTER SET utf8
    DEFAULT COLLATE utf8_general_ci;", DATABASE_NAME);

            _cmd.ExecuteNonQuery();

            _cmd.CommandText = String.Format("USE {0};", DATABASE_NAME);
            _cmd.ExecuteNonQuery();

            //Close();
        }

        protected void ExecuteNonQuery(string query)
        {
            ExecuteNonQuery(query, null);
        }

        protected void ExecuteNonQuery(string query, params object[] args)
        {
            if (_cmd != null)
            {
                if (args != null)
                {
                    _cmd.CommandText = String.Format(query, args);
                }
                else
                {
                    _cmd.CommandText = query;
                }

                _cmd.ExecuteNonQuery();
            }
        }

        protected void Open()
        {
            /*_con = new OleDbConnection(ConnectionString);
            _con.Open();
            _cmd = new OleDbCommand();
            _cmd.Connection = _con;*/

            _con = new MySqlConnection(ConnectionString);
            _con.Open();

            _cmd = new MySqlCommand();
            _cmd.Connection = _con;

            _isOpen = true;
        }

        protected void Close()
        {
            if (_con != null)
            {
                _con.Close();
                _cmd = null;
            }
            else
            {
                throw new Exception("Database is not open.");
            }

            _isOpen = false;
        }

        protected string ConnectionString
        {
            get
            {
                return "Server=127.0.0.1;Uid=root;Pwd=teddybear;Charset=utf8;";
            }
        }

        protected static string SQLDate(DateTime date)
        {
            //STR_TO_DATE('{2}','%m-%d-%Y %H:%i:%s'
            //12-01-2014 00:00:00
            return date.ToString("MM-dd-yyyy HH:mm:ss");
        }

        /*protected static DateTime ReadSQLDate(string sqlDate)
        {
            return DateTime.ParseExact(sqlDate, "MM-dd-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }*/

        public bool isOpen
        {
            get
            {
                return _isOpen;
            }
        }
    }
}
