using KlubHub.Model;
using KlubHub.Repository;


namespace KlubHub.Service
{
    public interface ILoginService
    {
        UserVM ValidateUser(Member companyUser);
    }
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private static bool _ensureCreated { get; set; } = false;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public UserVM ValidateUser(Member companyUser)
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
