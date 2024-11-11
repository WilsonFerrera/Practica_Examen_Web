using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.ConnectionManager
{
    public class DbConnection
    {
        private OleDbConnection _connection;
        private string _stringConnection;

        public DbConnection(string DataSource, string DataBase, string Provider)
        {
            _stringConnection = $"Provider={Provider};Data Source={DataSource};Initial Catalog={DataBase};Integrated Security=SSPI;True Server Certificate=False";

        }

        private void CreateConnection()
        {
           _connection = new OleDbConnection(_stringConnection) ;
        }

        public OleDbConnection Open()
        {
            if (_connection == null) return null ;

            if(_connection.State == ConnectionState.Open) return _connection ;
            else
            {
                _connection.Open();
                return _connection ;
            }
        }

        public void Close()
        {
            _connection.Close();
        }

    }
}
