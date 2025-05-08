using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerModel
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public Company(int companyId, string companyName)
        {
            CompanyId = companyId;
            CompanyName = companyName;
        }
    }
}
