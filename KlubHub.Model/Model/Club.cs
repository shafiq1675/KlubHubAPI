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
        public string ClubName { get; set; }
        public string? ClubTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }        
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
    }
}
