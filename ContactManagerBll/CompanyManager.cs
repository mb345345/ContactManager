using ContactManagerBll.Interfaces;
using ContactManagerDal;
using ContactManagerDal.Interfaces;
using ContactManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerBll
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyDal companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            this.companyDal = companyDal;
        }

        public List<Company> ReadCompanies()
        {
            return companyDal.ReadCompanies();
        }
    }
}
