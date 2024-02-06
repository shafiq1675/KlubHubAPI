using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlubHub.Model;
using KlubHub.Repo;

namespace KlubHub.Service
{
    public interface IUserService
    {
        void AddUser(CompanyUser companyUser);
        void UpdateUser(CompanyUser companyUser);
        IEnumerable<CompanyUser> GetAllUser();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(CompanyUser companyUser)
        {
            companyUser.UserId = Guid.NewGuid().ToString();
            companyUser.Id = Guid.NewGuid().ToString();
            companyUser.CreatedDate = DateTime.Now;
            companyUser.ModifiedDate = DateTime.Now;
            companyUser.IsDeleted = false;
            companyUser.CreatedBy = null;
            _userRepository.AddUser(companyUser);
        }

        public void UpdateUser(CompanyUser companyUser)
        {
            try
            {
                _userRepository.UpdateUser(companyUser);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CompanyUser> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }
    }
}
