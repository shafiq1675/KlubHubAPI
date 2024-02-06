using ThreeStoreOne.Data;
using ThreeStoreOne.Model;
using ThreeStoreOne.Repo;

namespace ThreeStoreOne.Service
{
    public interface ILoginService
    {
        bool ValidateUser(CompanyUser companyUser);
    }
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private static bool _ensureCreated { get; set; } = false;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public bool ValidateUser(CompanyUser companyUser)
        {
            try
            {
                return _loginRepository.ValidateUser(companyUser);                
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
