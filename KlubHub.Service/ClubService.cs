using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlubHub.Model;
using KlubHub.Repository;

namespace KlubHub.Service
{
    public interface IClubService
    {
        void AddClub(Club club);
        void UpdateClub(Club club);
        IEnumerable<Club> Get();
        Club Get(int clubId);
    }
    public class ClubService : IClubService
    {
        private readonly IClubRepository _userRepository;

        public ClubService(IClubRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddClub(Club club)
        {
            club.CreatedDate = DateTime.Now;
            club.ModifiedDate = DateTime.Now;
            club.IsDeleted = false;
            club.CreatedBy = 0;
            _userRepository.AddClub(club);
        }

        public void UpdateClub(Club club)
        {
            try
            {
                _userRepository.UpdateClub(club);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Club> Get()
        {
            return _userRepository.Get();
        }

        public Club Get(int clubId)
        {
            return _userRepository.Get(clubId);
        }
    }
}
