using ContactManagerModel;

namespace ContactManagerDal.Interfaces
{
    public interface ICompanyDal
    {
        List<Company> ReadCompanies();
    }
}