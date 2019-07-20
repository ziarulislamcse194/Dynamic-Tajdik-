using StockManagementWinApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementWinApp.DAL
{
    public class StockReportRepository
    {
        //Connection
        private string connectionString = ConfigurationManager.ConnectionStrings["StockManagementConnectionString"].ConnectionString;
        private SqlConnection sqlConnection;

        //Command
        private string commandString;
        private SqlCommand sqlCommand;


        public DataTable Search(Stock stock)
        {
            //
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            commandString = @"SELECT * FROM StockReport where StockDate 
            between '" + stock.FromStockDate + "' and '" + stock.ToStockDate + "' and StockStatus = '" + stock.StockStatus + "' ";

            sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            

            sqlConnection.Close();
            return dataTable;


        }

        

        public bool SearchExists(Stock stock)
        {
            //
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            commandString = @"SELECT * FROM StockReport where StockDate 
            between '" + stock.FromStockDate + "' and '" + stock.ToStockDate + "' and StockStatus = '" + stock.StockStatus + "' ";

            sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }

            return false;


        }
    }
}
