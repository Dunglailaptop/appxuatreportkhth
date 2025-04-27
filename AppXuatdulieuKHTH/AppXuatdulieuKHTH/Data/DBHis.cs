using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXuatDuLieuKHTH.Data
{
    public class DBHis
    {
        public class DbConnectionManager
        {
            private readonly string _connectionString;

            public DbConnectionManager()
            {
                _connectionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.99.250)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=Medilink)));User Id=medi;Password=medi;";

            }

            public OracleConnection GetConnection()
            {
                return new OracleConnection(_connectionString);
            }
        }
    }
}
