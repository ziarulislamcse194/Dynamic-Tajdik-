using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using StockManagementWinApp.Model;

namespace StockManagementWinApp.DAL
{
    public class StockInRepository
    {

        //Connection
        private string connectionString = ConfigurationManager.ConnectionStrings["StockManagementConnectionString"].ConnectionString;
        private SqlConnection sqlConnection;

        //Command
        private string commandString;
        private SqlCommand sqlCommand;


        public DataTable SelectCompany()
        {
            sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            commandString = @"select distinct CompanyId, CompanyName from [dbo].[ItemsView]";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            //
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DataRow row = dataTable.NewRow();
            row[0] = -1;
            row[1] = "--Select--";
            dataTable.Rows.InsertAt(row, 0);

            sqlConnection.Close();
            return dataTable;


        }



        public DataTable SelectCategory(Item item)
        {
            //
            sqlConnection.Open();

            commandString = @"select distinct CategoryId, CategoryName from [dbo].[ItemsView] where CompanyId='" + item.CompanyId + "'";

            sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            DataRow row = dataTable.NewRow();
            row[0] = -1;
            row[1] = "--Select--";
            dataTable.Rows.InsertAt(row, 0);

            sqlConnection.Close();
            return dataTable;


        }

        public DataTable SelectItem(Item item)
        {
            //
            sqlConnection.Open();
            commandString = @"select distinct Id, ItemName from [dbo].[ItemsView]  where CompanyId='" + item.CompanyId + "' and  CategoryId ='" + item.CategoryId + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            DataRow row = dataTable.NewRow();
            row[0] = -1;
            row[1] = "--Select--";
            dataTable.Rows.InsertAt(row, 0);

            sqlConnection.Close();
            return dataTable;

        }



        public DataTable ShowGridItem(Stock stock)
        {
            //
            sqlConnection.Open();

            commandString = @"select * from GridView where  ItemID = '" + stock.ItemID + "' and StockStatus='StockIn' order by  StockDate desc  ";

            sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();
            return dataTable;


        }

        public int Insert(Stock stock)
        {
            //
            sqlConnection.Open();

            commandString = @"INSERT INTO Stocks ( ItemID, StockStatus, Quantity,StockDate) VALUES ('" + stock.ItemID + "', 'StockIn', '" + stock.Quantity + "',(DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)))";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();

            //
            sqlConnection.Close();

            return isExecuted;
        }

        public int Update(Stock stock)
        {
            //
            sqlConnection.Open();

            commandString = @"Update Stocks set Quantity='" + stock.Quantity + "'  WHERE  Id= '" + stock.StockId + "' and ItemID= '" + stock.ItemID + "'";

            sqlCommand = new SqlCommand(commandString, sqlConnection);

            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();

            //
            sqlConnection.Close();

            return isExecuted;
        }

        public string LoadReorderLevel(Item item)
        {


            {
                string reorder = "<View> ";
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

        public string LoadAvailableQty(Stock stock)
        {


            {
                string availableQty = "<View> ";
                if (stock.ItemID > 0)
                {
                    sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    //
                    commandString = @"select case when ( select sum(Quantity)  from stocks where StockStatus='StockIn' and ItemID= " +
                        stock.ItemID + " ) -(select COALESCE(sum([Quantity]), 0) from stocks where ( [StockStatus] = 'Sold' or[StockStatus] = 'Damaged' or[StockStatus] = 'Lost') and ItemID = " +
                        stock.ItemID + ") is null then 0 else(select sum(Quantity)  from stocks where StockStatus = 'StockIn' and ItemID = " +
                        stock.ItemID + ") - (select COALESCE(sum([Quantity]),0) from stocks where ( [StockStatus] = 'Sold' or[StockStatus] = 'Damaged' or[StockStatus] = 'Lost') and ItemID = " + 
                        stock.ItemID + ") end as Quantity ";
                    /*
                    commandString = @"select ( select sum(Quantity)  from stocks where StockStatus='StockIn' and ItemID='" + stock.ItemID + "')" +
                        "-" +
                        "(select COALESCE(sum([Quantity]),0) from stocks where( [StockStatus]='Sold' or [StockStatus]='Damaged' or [StockStatus]='Lost') and ItemID='" + stock.ItemID + "')";
                        */

                    sqlCommand = new SqlCommand(commandString, sqlConnection);
                    //

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    availableQty = dataTable.Rows[0].ItemArray[0].ToString();
                    sqlConnection.Close();
                }

                return availableQty;

            }

        }

       

    }
}
