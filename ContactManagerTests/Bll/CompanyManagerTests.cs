using ContactManagerBll;
using ContactManagerBll.Interfaces;
using ContactManagerDal;
using ContactManagerDal.Interfaces;
using ContactManagerModel;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactManagerTests.Bll
{
    public class CompanyManagerTests
    {
        private void StartUp()
        {           
        }

        [Fact]
        public void CompanyManagerReturnsList()
        {
            StartUp();

            // arrange
            var companyDal = Substitute.For<ICompanyDal>();
            companyDal.ReadCompanies().Returns(
                new List<Company>
                {
                    new Company(1, "Company 1"),
                    new Company(2, "Company 2"),
                });
            var companyManager = new CompanyManager(companyDal);

            // act
            var companies = companyManager.ReadCompanies();

            // assert
            Assert.Equal(2, companies.Count);

            TearDown();
        }

        private void TearDown()
        {
        }
    }

}
