using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlubHub.Model;
using KlubHub.Repository;

namespace KlubHub.Service
{
    public interface IUserService
    {
        void AddUser(Member companyUser);
        void UpdateUser(Member companyUser);
        IEnumerable<Member> GetAllUser();
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(Member companyUser)
        {
            companyUser.UserId = Guid.NewGuid().ToString();
            companyUser.CreatedDate = DateTime.Now;
            companyUser.ModifiedDate = DateTime.Now;
            companyUser.IsDeleted = false;
            companyUser.CreatedBy = 0;
            _userRepository.AddUser(companyUser);
        }

        public void UpdateUser(Member companyUser)
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

        public IEnumerable<Member> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }
    }
}
