using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementWinApp.Model;

namespace StockManagementWinApp.DAL
{
    public class ItemReportRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["StockManagementConnectionString"].ConnectionString;
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private string commandString;

        public DataTable LoadComapny()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //
            commandString = @"select distinct CompanyId, CompanyName from [dbo].[ItemsView]";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            //
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            DataRow row = dataTable.NewRow();
            row[0] = -1;
            row[1] = "Please Select";
            dataTable.Rows.InsertAt(row, 0);

            sqlConnection.Close();
            return dataTable;
        }

        public DataTable LoadCategory(Item item)
        {


            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            commandString = @"select distinct CategoryId, CategoryName from [dbo].[ItemsView] ";
            //commandString = @"select distinct CategoryId, CategoryName from [dbo].[ItemsView] where CompanyId='" + item.CompanyId + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            //
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            DataRow row = dataTable.NewRow();
            row[0] = -1;
            row[1] = "Please Select";
            dataTable.Rows.InsertAt(row, 0);

            sqlConnection.Close();
            return dataTable;
        }

        public DataTable Search(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();


            if (stock.CategoryName == "")
            {
                commandString = @"select Items.ItemName,
iv.CompanyName,
iv.CategoryName,
Items.ReOrderQuantity, 
( case when ((select sum(quantity) from Stocks where Itemid = items.id and stockStatus = 'StockIn') 
- case when (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') is not null 
then  (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') else 0 end ) is null
then 0 else  ((select sum(quantity) from Stocks where Itemid = items.id and stockStatus = 'StockIn') 
- case when (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') is not null 
then  (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') else 0 end ) end )as Quantity
 from itemsview iv
 inner join Items on Items.Id = iv.Id
 where CompanyName = '" + stock.CompanyName + "'";
            }
            else if (stock.CompanyName == "")
            {
                commandString = @"select Items.ItemName,
iv.CompanyName,
iv.CategoryName,
Items.ReOrderQuantity, 
( case when ((select sum(quantity) from Stocks where Itemid = items.id and stockStatus = 'StockIn') 
- case when (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') is not null 
then  (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') else 0 end ) is null
then 0 else  ((select sum(quantity) from Stocks where Itemid = items.id and stockStatus = 'StockIn') 
- case when (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') is not null 
then  (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') else 0 end ) end )as Quantity
 from itemsview iv
 inner join Items on Items.Id = iv.Id
 where categoryname = '" + stock.CategoryName + "'";
            }
            else
            {
                commandString = @"select Items.ItemName,
iv.CompanyName,
iv.CategoryName,
Items.ReOrderQuantity, 
( case when ((select sum(quantity) from Stocks where Itemid = items.id and stockStatus = 'StockIn') 
- case when (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') is not null 
then  (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') else 0 end ) is null
then 0 else  ((select sum(quantity) from Stocks where Itemid = items.id and stockStatus = 'StockIn') 
- case when (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') is not null 
then  (select sum(quantity) from Stocks where Itemid = items.id and stockStatus != 'StockIn') else 0 end ) end )as Quantity
 from itemsview iv
 inner join Items on Items.Id = iv.Id
 where categoryname = '" + stock.CategoryName + "' AND CompanyName = '" + stock.CompanyName + "' ";
            }
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }


    }
}
