using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StockManagementWinApp.Model;

namespace StockManagementWinApp.DAL
{
    public class StockOutRepository
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["StockManagementConnectionString"].ConnectionString;

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

            //
            commandString = @"select distinct CategoryId, CategoryName from [dbo].[ItemsView] where CompanyId='" +
                            item.CompanyId + "'";
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

        public DataTable LoadItem(Item item)
        {


            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //
            commandString = @"select distinct Id, ItemName from [dbo].[ItemsView]  where CompanyId='" + item.CompanyId +
                            "' and  CategoryId ='" + item.CategoryId + "'";
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

        public string LoadReorderLevel(Item item)
        {
            {
                string reorder = "0";
                if (item.Id > 0)
                {
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    //
                    commandString = @"select distinct ReOrderQuantity from [dbo].[ItemsView] where Id= '" + item.Id +
                                    "'";
                    sqlCommand = new SqlCommand(commandString, sqlConnection);
                    //

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    reorder = dataTable.Rows[0].ItemArray[0].ToString();
                    sqlConnection.Close();
                }

                return reorder;
            }
        }

        public string LoadAvailableQuantity(Item item)
        {
            {
                string availableQuantity = "0";
                if (item.Id > 0)
                {
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    //
                    commandString = @"select case when (select  (select sum(quantity) from Stocks where Itemid = '" +
                        item.Id + "' and stockStatus = 'StockIn') - case when (select sum(quantity) from Stocks where Itemid = '" +
                        item.Id + "' and stockStatus != 'StockIn') is not null then  (select sum(quantity) from Stocks where Itemid = '" +
                        item.Id + "' and stockStatus != 'StockIn') else 0 end) is null then 0 else (select(select sum(quantity) from Stocks where Itemid = '" +
                        item.Id + "' and stockStatus = 'StockIn') - case when(select sum(quantity) from Stocks where Itemid = '" +
                        item.Id + "' and stockStatus != 'StockIn') is not null then(select sum(quantity) from Stocks where Itemid = '" +
                        item.Id+"' and stockStatus != 'StockIn') else 0 end) end as AvailableQuantity";
                    //commandString = @"select  (select sum(quantity) from Stocks where Itemid = '" + item.Id + "' and stockStatus = 'StockIn') - case when (select sum(quantity) from Stocks where Itemid = '" + item.Id + "' and stockStatus != 'StockIn') is not null then  (select sum(quantity) from Stocks where Itemid = '" + item.Id+"' and stockStatus != 'StockIn') else 0 end as AvailableQuantity";
                    sqlCommand = new SqlCommand(commandString, sqlConnection);
                    //

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    availableQuantity = dataTable.Rows[0].ItemArray[0].ToString();
                    sqlConnection.Close();
                }

                return availableQuantity;
            }
        }

        public int SellItem(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            commandString = @"insert into Stocks(StockDate,StockStatus,ItemID,Quantity) Values (cast(getdate() as date),'"+stock.StockStatus+"','"+stock.ItemID+"','"+stock.Quantity+"')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();
            //
            sqlConnection.Close();
            return isExecuted;
        }

        public int LostItem(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            commandString = @"insert into Stocks(StockDate,StockStatus,ItemID,Quantity) Values (cast(getdate() as date),'" + stock.StockStatus + "','" + stock.ItemID + "','" + stock.Quantity + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();
            //
            sqlConnection.Close();
            return isExecuted;
        }

        public int DamagedItem(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            commandString = @"insert into Stocks(StockDate,StockStatus,ItemID,Quantity) Values (cast(getdate() as date),'" + stock.StockStatus + "','" + stock.ItemID + "','" + stock.Quantity + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();
            //
            sqlConnection.Close();
            return isExecuted;
        }

        public DataTable ShowSellItem(Stock stock)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select * from Stocks where StockStatus='"+stock.StockStatus+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }



    }
}
