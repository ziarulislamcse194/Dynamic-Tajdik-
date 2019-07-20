using StockManagementWinApp.DAL;
using StockManagementWinApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockManagementWinApp.BLL
{
    public class StockReportManager
    {

        StockReportRepository _stockReportRepository = new StockReportRepository();
        public DataTable Search(Stock stock)
        {
            return _stockReportRepository.Search(stock);
        }
        public bool SearchExists(Stock stock)
        {
           
            return _stockReportRepository.SearchExists( stock);

        }
    }
}
