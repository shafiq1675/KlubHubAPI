using KlubHub.Model;
using KlubHub.Repo;

namespace KlubHub.Service
{
    public interface ICompanyService
    {
        void AddCompany(Company company);
        IEnumerable<Company> GetAllCompany();
    }
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public void AddCompany(Company company)
        {

            company.Id = Guid.NewGuid().ToString();
            company.CompanyId = Guid.NewGuid().ToString();
            company.CreatedDate = DateTime.Now;
            company.ModifiedDate = DateTime.Now;
            company.IsDeleted = false;
            company.CreatedBy = null;
            _companyRepository.AddCompany(company);

        }

        public IEnumerable<Company> GetAllCompany()
        {
            return _companyRepository.GetAllCompany();

        }
    }
}
