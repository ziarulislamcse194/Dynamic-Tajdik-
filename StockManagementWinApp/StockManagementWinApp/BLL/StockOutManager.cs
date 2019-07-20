using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementWinApp.DAL;
using StockManagementWinApp.Model;

namespace StockManagementWinApp.BLL
{
    public class StockOutManager
    {
        StockOutRepository _stockOutRepository= new StockOutRepository();
        public DataTable LoadCompany()
        {
            return _stockOutRepository.LoadComapny();
        }

        public DataTable LoadCategory(Item item)
        {
            return _stockOutRepository.LoadCategory(item);
        }

        public DataTable LoadItem(Item item)
        {
            return _stockOutRepository.LoadItem(item);
        }

        public string LoadReorderLevel(Item item)
        {
            return _stockOutRepository.LoadReorderLevel(item);
        }

        public string LoadAvailableQuantity(Item item)
        {
            return _stockOutRepository.LoadAvailableQuantity(item);
        }

        public int SellItem(Stock stock)
        {
            return _stockOutRepository.SellItem(stock);
        }

        public int LostItem(Stock stock)
        {
            return _stockOutRepository.LostItem(stock);
        }

        public int DamagedItem(Stock stock)
        {
            return _stockOutRepository.DamagedItem(stock);
        }

        public DataTable ShowSellItem(Stock stock)
        {
           
            return _stockOutRepository.ShowSellItem(stock);
        }







    }
}
