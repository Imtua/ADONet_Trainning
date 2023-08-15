using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetLib
{
    public class DbExecutor
    {
        private MainConnection _connector;

        public DbExecutor(MainConnection mainConnection)
        {
            _connector = mainConnection;
        }

        public DataTable SelectAll(string tableName)
        {
            var selectionCommand = "SELECT * FROM " + tableName;
            var adapter = new SqlDataAdapter(selectionCommand, _connector.GetConnection());
            var dataSet = new DataSet();

            adapter.Fill(dataSet);

            return dataSet.Tables[0];
        }
    }
}
