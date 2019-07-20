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
    public class CompanyRepository
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["StockManagementConnectionString"].ConnectionString;
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private string commandString;

        public bool Insert(Company company)
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"Insert into Companys(CompanyName) values('" + company.CompanyName + "') ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            bool IsAuth = false;
            int IsExecuted = sqlCommand.ExecuteNonQuery();
            if (IsExecuted > 0)
            {

                IsAuth = true;
            }
            sqlConnection.Close();
            return IsAuth;

        }

        public DataTable ShowCompany()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select * from Companys";
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
            commandString = @"select * from Companys where CompanyName = '" + name + "' ";
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
            commandString = @"select * from Companys where CompanyName = '" + name + "' and id != "+id+" ";
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
        public bool Update(Company company)
        {

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"Update Companys set CompanyName = '" + company.CompanyName + "' where Id = "+company.Id+" ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            bool IsAuth = false;
            int IsExecuted = sqlCommand.ExecuteNonQuery();
            if (IsExecuted > 0)
            {

                IsAuth = true;
            }
            sqlConnection.Close();
            return IsAuth;

        }

    }
}
