using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface ILoginRepository
    {
        UserVM ValidateUser(CompanyUser companyUser);
    }
    public class LoginRepository: ILoginRepository
    {
        private readonly StoreDbContext _dbContext;
        private static bool _ensureCreated { get; set; } = false;

        public LoginRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;

            if (!_ensureCreated)
            {
                _dbContext.Database.EnsureCreated();
                _ensureCreated = true;
            }
        }
        public UserVM ValidateUser(CompanyUser companyUser)
        {
            try
            {
                var response = new UserVM();
                var result = _dbContext.CompanyUsers.FirstOrDefault(x => (x.UserName == companyUser.UserName || x.UserEmail == companyUser.UserName) && x.Password == companyUser.Password);
                if (result == null)
                {
                    return response;
                }
                else
                {
                    var company = _dbContext.Companies.Where(x=>x.CompanyId == result.CompanyId).FirstOrDefault();
                    response.CompanyName= company.CompanyName;
                    response.UserEmail = result.UserEmail;
                    response.UserName = result.UserName;
                    response.CompanyId = result.CompanyId;
                    response.UserFullName = result.UserFullName;
                    return response;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
