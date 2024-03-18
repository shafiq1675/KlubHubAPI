using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlubHub.Model
{
    public class OrgType
    {
        public int OrgTypeId { set; get; }
        public string OrgTypeName { set; get; }
        public DateTime? CreatedDate { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public bool? IsDeleted { set; get; }
        public int CreatedBy { set; get; }
    }
}
