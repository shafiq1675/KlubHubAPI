using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repo
{
    public interface IUserRepository
    {
        void AddUser(CompanyUser companyUser);
        void UpdateUser(CompanyUser companyUser);
        IEnumerable<CompanyUser> GetAllUser();
    }
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;
        private static bool _ensureCreated { get; set; } = false;

        public UserRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;

            if (!_ensureCreated)
            {
                _dbContext.Database.EnsureCreated();
                _ensureCreated = true;
            }
        }
        public void AddUser(CompanyUser companyUser)
        {
            companyUser.UserId = Guid.NewGuid().ToString();
            companyUser.Id = Guid.NewGuid().ToString();
            companyUser.CreatedDate = DateTime.Now;
            companyUser.ModifiedDate = DateTime.Now;
            companyUser.IsDeleted = false;
            companyUser.CreatedBy = null;
            _ = _dbContext.CompanyUsers.Add(companyUser);
            _dbContext.SaveChangesAsync();
        }

        public void UpdateUser(CompanyUser companyUser)
        {
            CompanyUser? tempUser = _dbContext.CompanyUsers.FirstOrDefault(x => x.UserId == companyUser.UserId);
            if (tempUser != null)
            {
                tempUser.UserRole = companyUser.UserRole;
                tempUser.ModifiedDate = DateTime.Now;
                _ = _dbContext.CompanyUsers.Update(tempUser);
                _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<CompanyUser> GetAllUser()
        {
            return _dbContext.CompanyUsers.ToList();
        }
    }
}
