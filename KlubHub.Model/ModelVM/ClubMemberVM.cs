using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlubHub.Model
{
    public class ClubMemberVM
    {
        public int ClubMemberId { get; set; }
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public string? ClubDescription { get; set; }
        public string? ClubAddress { get; set; }
        public string? ClubEmail { get; set; }
        public string? ClubImageUrl { get; set; }
        public string? ClubContactNumber { get; set; }
        public int MemberId { get; set; }
        public string? MemberFullName { get; set; }
        public string? MemberUserName { get; set; }
        public string? MemberEmail { get; set; }
        public string? MemberContactNumber { get; set; }

    }
}
