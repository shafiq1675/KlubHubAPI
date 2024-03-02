using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface ILoginRepository
    {
        UserVM ValidateUser(Member companyUser);
    }
    public class LoginRepository: ILoginRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public LoginRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;           
        }
        public UserVM ValidateUser(Member companyUser)
        {
            try
            {
                var response = new UserVM();
                var result = _dbContext.Member.FirstOrDefault(x => (x.UserName == companyUser.UserName || x.UserEmail == companyUser.UserName) && x.Password == companyUser.Password);
                if (result == null)
                {
                    throw new Exception("User Not Found.!");
                }
                else
                {
                    response.UserEmail = result.UserEmail;
                    response.UserName = result.UserName;
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
