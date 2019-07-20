using StockManagementWinApp.DAL;
using StockManagementWinApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementWinApp.BLL
{
    public class UserManager
    {
        UserRepository _userRepository = new UserRepository(); 
        public bool UserAuth(User user)
        {
           
            return _userRepository.UserAuth(user);
        }
    }
}
