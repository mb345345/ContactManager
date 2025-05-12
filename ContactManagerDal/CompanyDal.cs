using ContactManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ContactManagerDal.Extensions;
using ContactManagerDal.Interfaces;

namespace ContactManagerDal
{
    public class CompanyDal : ICompanyDal
    {
        private readonly string connectionString;

        public CompanyDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Company> ReadCompanies()
        {
            List<Company> companies = new List<Company>();

            // connect to db
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    // Creating the command object
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Company ORDER BY CompanyName", sqlConnection);

                    // Opening Connection  
                    sqlConnection.Open();

                    // run query
                    SqlDataReader reader = cmd.ExecuteReader();

                    //Looping through each record
                    while (reader.Read())
                    {
                        int companyId = reader.GetValueOrDefault<int>("CompanyId");
                        string companyName = reader.GetValueOrDefault<string>("CompanyName");

                        companies.Add(new Company(companyId, companyName));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

            return companies;
        }
    }
}
