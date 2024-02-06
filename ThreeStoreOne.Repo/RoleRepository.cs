using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repo
{
    public interface IRoleRepository
    {
        void AddUserRole(UserRole userRole);
        IEnumerable<UserRole> GetAllUserRole();
    }
    public class RoleRepository : IRoleRepository
    {
        private readonly StoreDbContext _dbContext;
        private static bool _ensureCreated { get; set; } = false;


        public RoleRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;

            if (!_ensureCreated)
            {
                _dbContext.Database.EnsureCreated();
                _ensureCreated = true;
            }
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
