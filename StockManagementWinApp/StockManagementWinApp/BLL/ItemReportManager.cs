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
    public class ItemReportManager
    {

        ItemReportRepository _itemReportRepository=new ItemReportRepository();
        public DataTable LoadCompany()
        {
            return _itemReportRepository.LoadComapny();
        }

        public DataTable LoadCategory(Item item)
        {
            return _itemReportRepository.LoadCategory(item);
        }

        public DataTable Search(Stock stock)
        {
            return _itemReportRepository.Search(stock);
        }

    }
}
