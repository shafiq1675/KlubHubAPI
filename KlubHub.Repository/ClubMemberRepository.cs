using KlubHub.Data;
using KlubHub.Model;
using Microsoft.EntityFrameworkCore;

namespace KlubHub.Repository
{
    public interface IClubMemberRepository
    {
        void AddClubMember(ClubMember clubMember);
        void UpdateClubMember(ClubMember clubMember);
        IEnumerable<ClubMember> GetByClubId(int clubId);
        IEnumerable<ClubMember> GetByMemberId(int memberId);
    }
    public class ClubMemberRepository : IClubMemberRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public ClubMemberRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddClubMember(ClubMember clubMember)
        {
            try
            {
                clubMember.CreatedDate = DateTime.Now;
                clubMember.ModifiedDate = DateTime.Now;
                clubMember.IsDeleted = false;
                clubMember.IsActive = true;
                _ = _dbContext.ClubMember.Add(clubMember);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public void UpdateClubMember(ClubMember clubMember)
        {
            ClubMember? tempUser = _dbContext.ClubMember.FirstOrDefault(x => x.ClubMemberId == clubMember.ClubMemberId);
            if (tempUser != null)
            {
                tempUser.MemberId = clubMember.MemberId;
                tempUser.ClubId = clubMember.ClubId;
                tempUser.ClubId = clubMember.ClubId;
                tempUser.ClubId = clubMember.ClubId;
                tempUser.ModifiedDate = DateTime.Now;
                _ = _dbContext.ClubMember.Update(tempUser);
                _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<ClubMember> GetByClubId(int clubId)
        {
            return _dbContext.ClubMember.Where(x=>x.ClubId == clubId).ToList();
        }
        public IEnumerable<ClubMember> GetByMemberId(int memberId)
        {
            return _dbContext.ClubMember.Where(x => x.ClubMemberId == memberId).ToList();
        }
    }
}
