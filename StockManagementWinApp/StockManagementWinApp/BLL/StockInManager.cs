using StockManagementWinApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementWinApp.Model;

namespace StockManagementWinApp.BLL
{
    public class StockInManager
    {


        StockInRepository _stockInRepository = new StockInRepository();

        public DataTable SelectCompany()
        {

            return _stockInRepository.SelectCompany();

        }
        public DataTable SelectCategory(Item item)
        {
            return _stockInRepository.SelectCategory(item);
        }

        public DataTable SelectItem(Item item)
        {
            return _stockInRepository.SelectItem(item);
        }
        //public DataTable SelectItemAll(Item item)
        //{
        //    return _stockInRepository.SelectItemAll(item);
        //}
        public DataTable ShowGridItem(Stock stock)
        {
            return _stockInRepository.ShowGridItem(stock);
        }

        public int Insert(Stock stock)
        {
            return _stockInRepository.Insert(stock);
        }
        public int Update(Stock stock)
        {

            return _stockInRepository.Update(stock);

        }

        public string LoadReorderLevel(Item item)
        {
            return _stockInRepository.LoadReorderLevel(item);
        }
        public string LoadAvailableQty(Stock stock)
        {
            return _stockInRepository.LoadAvailableQty(stock);
        }
    }
}
