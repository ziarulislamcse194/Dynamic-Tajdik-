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
    public class CategoryManager
    {
        CategoryRepository _CategoryRepository = new CategoryRepository();

        public bool Insert(Category category)
        {

            return _CategoryRepository.Insert(category);

        }

        public DataTable ShowCategory()
        {
            return _CategoryRepository.ShowCategory();
        }

        public bool IsExists(string name)
        {
            return _CategoryRepository.IsExists(name);
        }

        public bool Update(Category category)
        {

            return _CategoryRepository.Update( category);

        }
        public bool IsExistsUpdate(string name, string id)
        {

            return _CategoryRepository.IsExistsUpdate( name,  id);

        }
    }
}

