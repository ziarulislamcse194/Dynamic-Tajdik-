using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementWinApp.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ReOrderQuantity { get; set; }
        public int Quantity { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
