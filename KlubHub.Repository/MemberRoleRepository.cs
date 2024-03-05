using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface IMemberRoleRepository
    {
        void AddMemberRole(MemberRole MemberRole);
        IEnumerable<MemberRole> GetAllMemberRole();
    }
    public class MemberRoleRepository : IMemberRoleRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public MemberRoleRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddMemberRole(MemberRole MemberRole)
        {

            MemberRole.CreatedDate = DateTime.Now;
            MemberRole.ModifiedDate = DateTime.Now;
            MemberRole.IsDeleted = false;
            MemberRole.CreatedBy = 0;

            _ = _dbContext.MemberRoles.Add(MemberRole);
            _dbContext.SaveChangesAsync();
        }

        public IEnumerable<MemberRole> GetAllMemberRole()
        {
            return _dbContext.MemberRoles.ToList();
        }
    }
}
