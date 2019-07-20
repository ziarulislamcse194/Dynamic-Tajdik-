using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementWinApp.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string StockStatus { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        //public int QuantityId { get; set; }
        //public string QuantityName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public string StockDate { get; set; }

        public DateTime FromStockDate { get; set; }
        public DateTime ToStockDate { get; set; }
        public int ReorderLevel{ get; set; }



    }
}
