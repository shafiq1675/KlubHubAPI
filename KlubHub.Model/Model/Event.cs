using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlubHub.Model
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string? EventDescription { get; set; }
        public string? EventPlace { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }        
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
    }
}
