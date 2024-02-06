using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repo
{
    public interface ICompanyRepository
    {
        void AddCompany(Company company);
        IEnumerable<Company> GetAllCompany();
    }
    public class CompanyRepository : ICompanyRepository
    {
        private readonly StoreDbContext _dbContext;
        private static bool _ensureCreated { get; set; } = false;

        public CompanyRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;

            if (!_ensureCreated)
            {
                _dbContext.Database.EnsureCreated();
                _ensureCreated = true;
            }
        }
        public void AddCompany(Company company)
        {

            company.Id = Guid.NewGuid().ToString();
            company.CompanyId = Guid.NewGuid().ToString();
            company.CreatedDate = DateTime.Now;
            company.ModifiedDate = DateTime.Now;
            company.IsDeleted = false;
            company.CreatedBy = null;
            _ = _dbContext.Companies.Add(company);
            _dbContext.SaveChangesAsync();

        }

        public IEnumerable<Company> GetAllCompany()
        {
            return _dbContext.Companies.ToList();

        }
    }
}
