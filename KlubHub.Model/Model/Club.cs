using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlubHub.Model
{
    public class Club
    {
        public int ClubId { get; set; }
        public int OrgTypeId { get; set; }
        public string ClubName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? ContactNumber{ get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }        
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
    }
}
