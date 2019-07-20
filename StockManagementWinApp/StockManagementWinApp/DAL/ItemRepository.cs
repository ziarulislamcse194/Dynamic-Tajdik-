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
    public class ItemRepository
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["StockManagementConnectionString"].ConnectionString;
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private string commandString;

        public bool Insert(Item item)
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"Insert into Items(ItemName,ReOrderQuantity,CompanyID,CategoryID) values('"+ item.ItemName+"',"+item.ReOrderQuantity+","+item.CompanyId+","+item.CategoryId+")  ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            bool IsAuth = false;
            int IsExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (IsExecuted > 0)
            {
                IsAuth = true;
            }
            return IsAuth;

        }

        public DataTable ShowItem()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select * from ItemsView";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            if (dataTable.Rows.Count > 0)
            {

                return dataTable;
            }

            return dataTable;
        }

        public DataTable LoadCompany()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select * from Companys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            DataRow row = dataTable.NewRow();
            row[0] = -1;
            row[1] = "Please Select";
            dataTable.Rows.InsertAt(row, 0);
            if (dataTable.Rows.Count > 0)
            {

                return dataTable;
            }

            return dataTable;
        }

        public DataTable LoadCategory()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select * from Categorys";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            DataRow row = dataTable.NewRow();
            row[0] = -1;
            row[1] = "Please Select";
            dataTable.Rows.InsertAt(row, 0);
            if (dataTable.Rows.Count > 0)
            {

                return dataTable;
            }

            return dataTable;
        }

        public bool IsExists(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select id from [ItemsView] where CompanyId = "+item.CompanyId+" and CategoryId = "+ item.CategoryId+ " and ItemName = '"+item.ItemName+"' ";
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

        public bool Update(Item item)
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"Update Items set ItemName = '" + item.ItemName + "' , ReOrderQuantity  = " + item.ReOrderQuantity + " where id = "+item.Id+" ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            bool IsAuth = false;
            int IsExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (IsExecuted > 0)
            {
                IsAuth = true;
            }
            return IsAuth;

        }

        public bool IsExistsItemName(Item item)
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select id from [ItemsView] where CompanyId = " + item.CompanyId + " and CategoryId = " + item.CategoryId + " and ItemName = '" + item.ItemName + "' and id !="+item.Id+" ";
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
