using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppXuatDuLieuKHTH.Data.DBHis;

namespace AppXuatDuLieuKHTH.Data
{
    public class ConnectionDB
    {
        private readonly DbConnectionManager _connectionManager;

        public ConnectionDB()
        {
            _connectionManager = new DbConnectionManager();
        }

        public async Task<DataTable> GetConnectionList(string query)
        {
            var result = new DataTable();
            try
            {
                using (var connection = _connectionManager.GetConnection())
                {
                    await connection.OpenAsync();

                    using (var command = new OracleCommand(query, connection))
                    {
                        using (var adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(result);
                        }
                    }
                }
                return result;
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                throw;
            }
        }


        public async Task<DataTable> GetConnectionAsync(string query, string name_value, object Values, DataTable result)
        {
            try
            {
                using (var connection = _connectionManager.GetConnection())
                {
                    await connection.OpenAsync();

                    using (var command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new OracleParameter(name_value, OracleDbType.Varchar2) { Value = Values });

                        using (var adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(result);
                        }
                    }
                }
                return result;
            }
            catch (OracleException ex)
            {
                // Log the error (e.g., using a logging framework)
                Console.WriteLine($"Database error: {ex.Message}");
                throw; // Rethrow or handle as needed
            }
        }

    }
}
