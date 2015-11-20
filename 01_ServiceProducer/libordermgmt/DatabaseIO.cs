using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace libordermgmt
{
    public abstract class DatabaseIO
    {
        FileInfo _file;
        OleDbConnection _con;
        OleDbCommand _cmd;

        protected DatabaseIO(string fileName)
        {
            // for security, remove invalid characters and limit file name to 10
            //fileName = Regex.Replace(fileName, "[^0-9a-zA-Z_.-]+", "");
            //fileName = fileName.Substring(0, 30);

            //_file = new FileInfo(String.Format("{0}{1}", BASE_PATH, fileName));
            _file = new FileInfo(fileName);

            if (!_file.Exists)
            {
                CreateDatabase();
            }
        }

        /*public DatabaseIO()
        {
            _file = new FileInfo(MDB_PATH);

            if (!_file.Exists)
            {
                CreateDatabase();
            }
        }*/

        public void Reset()
        {
            if (_file.Exists)
            {
                _file.Delete();
            }

            CreateDatabase();
        }

        protected virtual void CreateDatabase()
        {
            ADOX.Catalog cat;

            // Create MDB
            cat = new ADOX.Catalog();
            cat.Create(ConnectionString);
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

        protected OleDbCommand Open()
        {
            _con = new OleDbConnection(ConnectionString);
            _con.Open();
            _cmd = new OleDbCommand();
            _cmd.Connection = _con;

            return _cmd;
        }

        public SqlCommand OpenForQuery()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            
        }

        public void Close()
        {
            if (_con != null)
            {
                _cmd = null;
                _con.Close();
            }
            else
            {
                throw new Exception("Database is not open.");
            }
        }

        protected string ConnectionString
        {
            get
            {
                return String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\"", _file.FullName);
            }
        }
    }
}
