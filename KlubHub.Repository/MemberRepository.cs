using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface IMemberRepository
    {
        void AddMember(Member member);
        void UpdateMember(Member member);
        IEnumerable<Member> GetAllUser();
    }
    public class MemberRepository : IMemberRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public MemberRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddMember(Member member)
        {
            try
            {
                member.CreatedDate = DateTime.Now;
                member.ModifiedDate = DateTime.Now;
                member.IsDeleted = false;
                member.CreatedBy = 0;
                _ = _dbContext.Member.Add(member);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public void UpdateMember(Member member)
        {
            Member? tempUser = _dbContext.Member.FirstOrDefault(x => x.Id == member.Id);
            if (tempUser != null)
            {
                tempUser.MemberRoleId = member.MemberRoleId;
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
