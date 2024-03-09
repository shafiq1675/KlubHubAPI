using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlubHub.Model
{
    public class ClubMember
    {
        public int ClubMemberId { set; get; }
        public int ClubId { set; get; }
        public int MemberId { set; get; }
        public DateTime? CreatedDate { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public bool IsDeleted { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
    }
}
