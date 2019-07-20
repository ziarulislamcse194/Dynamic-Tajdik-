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
    public class CategoryRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["StockManagementConnectionString"].ConnectionString;
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private string commandString;

        public bool Insert(Category category)
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"Insert into Categorys(CategoryName)  values('" + category.CategoryName + "') ";
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

        public DataTable ShowCategory()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select * from Categorys";
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

        public bool IsExists(string name)
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select * from Categorys where CategoryName = '" + name + "' ";
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

        public bool IsExistsUpdate(string name,string id)
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select * from Categorys where CategoryName = '" + name + "' and id != "+id+" ";
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

        public bool Update(Category category)
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"Update Categorys set CategoryName = '" + category.CategoryName + "' where id = "+category.Id+" ";
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

    }
}
