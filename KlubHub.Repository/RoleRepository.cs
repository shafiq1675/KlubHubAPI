using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface IRoleRepository
    {
        void AddUserRole(UserRole userRole);
        IEnumerable<UserRole> GetAllUserRole();
    }
    public class RoleRepository : IRoleRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public RoleRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddUserRole(UserRole userRole)
        {

            userRole.CreatedDate = DateTime.Now;
            userRole.ModifiedDate = DateTime.Now;
            userRole.IsDeleted = false;
            userRole.CreatedBy = "";

            _ = _dbContext.UserRoles.Add(userRole);
            _dbContext.SaveChangesAsync();
        }

        public IEnumerable<UserRole> GetAllUserRole()
        {
            return _dbContext.UserRoles.ToList();
        }
    }
}
