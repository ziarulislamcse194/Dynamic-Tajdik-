using StockManagementWinApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace StockManagementWinApp.DAL
{
    public class UserRepository
    {
        //private string connectionString = @"Server; Database=StockManagementDB; Integrated Security= True;";
        private string connectionString = ConfigurationManager.ConnectionStrings["StockManagementConnectionString"].ConnectionString;

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private string commandString;
        //sqlConnection = new SqlConnection(connectionString);

        public  bool UserAuth(User user)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commandString = @"select id from Users where Username = '"+user.UserName+"' and [Password] = '"+user.Password+"' ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            bool IsAuth = false;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {

                IsAuth = true;
            }
            sqlConnection.Close();
            return IsAuth;
        }
    }
}
