using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System;

namespace CBRN_Project
{
    class DataService
    {

        static DataSet ds = new DataSet();
        static SqlConnection connection;

        static public void Initialize()
        {
            var nw = ConfigurationManager.ConnectionStrings["conStr"];
            connection = new SqlConnection(nw.ConnectionString);
            connection.Open();

        }


        static public DataTable GetTable(string tableName)
        {
            LoadTable(tableName);
            return ds.Tables[tableName];
        }

        private static void LoadTable(string tableName)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM " + tableName;
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, tableName);
        }

        static public object GetValueFromTable(string tableName, int rowIndex, string columnName)
        {
            return GetTable(tableName).Rows[rowIndex][columnName];
        }
    }
}
