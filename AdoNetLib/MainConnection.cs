using AdoNetLib.Connections;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetLib
{
    public class MainConnection
    {
        private SqlConnection _connection;
        public async Task<bool> ConnectAsync()
        {
            bool result = false;
            try
            {
                _connection = new SqlConnection(ConnectionString.MsSqlConnection);
                await _connection.OpenAsync();
                result = true;
            }
            catch (Exception) { }

            return result;
        }

        public async void DisconnectAsync()
        {
            if (_connection.State==ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                throw new Exception("Подключение закрыто");
            }
            return _connection;
        }
    }
}