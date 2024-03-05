using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlubHub.Model;
using KlubHub.Repository;

namespace KlubHub.Service
{
    public interface IMemberService
    {
        void AddMember(Member member);
        void UpdateMember(Member member);
        IEnumerable<Member> GetAllUser();
    }
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _userRepository;

        public MemberService(IMemberRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddMember(Member member)
        {
            member.CreatedDate = DateTime.Now;
            member.ModifiedDate = DateTime.Now;
            member.IsDeleted = false;
            member.CreatedBy = 0;
            _userRepository.AddMember(member);
        }

        public void UpdateMember(Member member)
        {
            try
            {
                _userRepository.UpdateMember(member);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Member> GetAllUser()
        {
            return _userRepository.GetAllUser();
        }
    }
}
