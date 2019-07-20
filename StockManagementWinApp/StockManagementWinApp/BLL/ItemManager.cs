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
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();
        public bool Insert(Item item)
        {
            return _itemRepository.Insert(item);
        }

        public DataTable ShowItem()
        {   
            return _itemRepository.ShowItem();
        }

        public DataTable LoadCompany()
        {
            return _itemRepository.LoadCompany();
        }

        public DataTable LoadCategory()
        {
            return _itemRepository.LoadCategory();
        }

        public bool IsExists(Item item)
        {
            return _itemRepository.IsExists(item);
        }

        public bool Update(Item item)
        {
            return _itemRepository.Update( item);
        }

        public bool IsExistsItemName(Item item)
        { 
            return _itemRepository.IsExistsItemName( item);
        }
    }
}
