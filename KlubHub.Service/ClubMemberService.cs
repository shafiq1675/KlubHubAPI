using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlubHub.Model;
using KlubHub.Repository;

namespace KlubHub.Service
{
    public interface IClubMemberService
    {
        void AddClubMember(ClubMember clubMember);
        void UpdateClubMember(ClubMember clubMember);
        IEnumerable<ClubMemberVM> GetByClubId(int clubId);
        IEnumerable<ClubMemberVM> GetByMemberId(int memberId);
    }
    public class ClubMemberService : IClubMemberService
    {
        private readonly IClubMemberRepository _clubMemberRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IMemberRepository _memberRepository;

        public ClubMemberService(IClubMemberRepository clubMemberRepository, IClubRepository clubRepository, IMemberRepository memberRepository)
        {
            _clubMemberRepository = clubMemberRepository;
            _clubRepository = clubRepository;
            _memberRepository = memberRepository;
        }
        public void AddClubMember(ClubMember clubMember)
        {
            clubMember.CreatedDate = DateTime.Now;
            clubMember.ModifiedDate = DateTime.Now;
            clubMember.IsDeleted = false;
            clubMember.CreatedBy = 0;
            _clubMemberRepository.AddClubMember(clubMember);
        }

        public void UpdateClubMember(ClubMember clubMember)
        {
            try
            {
                _clubMemberRepository.UpdateClubMember(clubMember);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ClubMemberVM> GetByClubId(int clubId)
        {
            try
            {
                var result = _clubMemberRepository.GetByClubId(clubId).ToList();
                var res = from clubMember in result
                          join club in _clubRepository.Get().ToList() on clubMember.ClubId equals club.ClubId
                          join mem in _memberRepository.GetAllMember().ToList() on clubMember.MemberId equals mem.Id
                          where clubMember.ClubId == clubId
                          select new ClubMemberVM
                          {
                              MemberId = mem.Id,
                              ClubId = clubMember.ClubId,
                              ClubMemberId = clubMember.ClubMemberId,
                              ClubAddress = club.Address,
                              ClubContactNumber = club.ContactNumber,
                              ClubDescription = club.Description,
                              ClubEmail = club.Email,
                              ClubImageUrl = club.ImageUrl,
                              ClubName = club.ClubName,
                              MemberContactNumber = mem.MemberContactNumber,
                              MemberEmail = mem.MemberEmail,
                              MemberFullName = mem.MemberFullName,
                              MemberUserName = mem.MemberUserName
                          };

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClubMemberVM> GetByMemberId(int memberId)
        {
            try
            {
                var result = _clubMemberRepository.GetByMemberId(memberId).ToList();
                var res = from clubMember in result
                          join club in _clubRepository.Get().ToList() on clubMember.ClubId equals club.ClubId
                          join mem in _memberRepository.GetAllMember().ToList() on clubMember.MemberId equals mem.Id
                          where clubMember.MemberId == memberId
                          select new ClubMemberVM
                          {
                              MemberId = mem.Id,
                              ClubId = clubMember.ClubId,
                              ClubMemberId = clubMember.ClubMemberId,
                              ClubAddress = club.Address,
                              ClubContactNumber = club.ContactNumber,
                              ClubDescription = club.Description,
                              ClubEmail = club.Email,
                              ClubImageUrl = club.ImageUrl,
                              ClubName = club.ClubName,
                              MemberContactNumber = mem.MemberContactNumber,
                              MemberEmail = mem.MemberEmail,
                              MemberFullName = mem.MemberFullName,
                              MemberUserName = mem.MemberUserName
                          };

                return res;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
