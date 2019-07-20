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
    public class CompanyManager
    {
        CompanyRepository _companyRepository = new CompanyRepository();

        public bool Insert(Company company)
        {
            return _companyRepository.Insert(company);
        }

        public DataTable ShowCompany()
        {
            return _companyRepository.ShowCompany();
        }

        public bool IsExists(string name)
        {
            return _companyRepository.IsExists(name);
        }

        public bool Update(Company company)
        { 
            return _companyRepository.Update( company);

        }

        public bool IsExistsUpdate(string name, string id)
        {
            
            return _companyRepository.IsExistsUpdate( name,  id);

        }
    }
}
