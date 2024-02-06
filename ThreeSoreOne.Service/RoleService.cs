using ThreeStoreOne.Data;
using ThreeStoreOne.Model;
using ThreeStoreOne.Repo;

namespace ThreeStoreOne.Service
{
    public interface IRoleService
    {
        void AddUserRole(UserRole userRole);
        IEnumerable<UserRole> GetAllUserRole();
    }
    public class RoleService : IRoleService
    {
        private readonly RoleRepository _roleRepository;
        private static bool _ensureCreated { get; set; } = false;


        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;

        }
        public void AddUserRole(UserRole userRole)
        {
            try
            {
                userRole.CreatedDate = DateTime.Now;
                userRole.ModifiedDate = DateTime.Now;
                userRole.IsDeleted = false;
                userRole.CreatedBy = "";

                _roleRepository.AddUserRole(userRole);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IEnumerable<UserRole> GetAllUserRole()
        {
            return _roleRepository.GetAllUserRole();
        }
    }
}
