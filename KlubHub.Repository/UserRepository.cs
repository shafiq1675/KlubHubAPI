using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface IUserRepository
    {
        void AddUser(Member companyUser);
        void UpdateUser(Member companyUser);
        IEnumerable<Member> GetAllUser();
    }
    public class UserRepository : IUserRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public UserRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddUser(Member companyUser)
        {
            companyUser.UserId = Guid.NewGuid().ToString();
            companyUser.CreatedDate = DateTime.Now;
            companyUser.ModifiedDate = DateTime.Now;
            companyUser.IsDeleted = false;
            companyUser.CreatedBy = 0;
            _ = _dbContext.Member.Add(companyUser);
            _dbContext.SaveChangesAsync();
        }

        public void UpdateUser(Member companyUser)
        {
            Member? tempUser = _dbContext.Member.FirstOrDefault(x => x.UserId == companyUser.UserId);
            if (tempUser != null)
            {
                tempUser.UserRole = companyUser.UserRole;
                tempUser.ModifiedDate = DateTime.Now;
                _ = _dbContext.Member.Update(tempUser);
                _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Member> GetAllUser()
        {
            return _dbContext.Member.ToList();
        }
    }
}
