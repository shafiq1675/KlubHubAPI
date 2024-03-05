using KlubHub.Data;
using KlubHub.Model;

namespace KlubHub.Repository
{
    public interface IClubRepository
    {
        void AddClub(Club member);
        void UpdateClub(Club member);
        IEnumerable<Club> Get();
    }
    public class ClubRepository : IClubRepository
    {
        private readonly KlubHubDbContext _dbContext;

        public ClubRepository(KlubHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddClub(Club club)
        {
            try
            {
                club.CreatedDate = DateTime.Now;
                club.ModifiedDate = DateTime.Now;
                club.IsDeleted = false;
                _ = _dbContext.Club.Add(club);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public void UpdateClub(Club club)
        {
            Club? tempUser = _dbContext.Club.FirstOrDefault(x => x.ClubId == club.ClubId);
            if (tempUser != null)
            {
                tempUser.ModifiedDate = DateTime.Now;
                _ = _dbContext.Club.Update(tempUser);
                _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Club> Get()
        {
            return _dbContext.Club.ToList();
        }
    }
}
