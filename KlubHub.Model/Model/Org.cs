using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlubHub.Model
{
    public class Org
    {
        [Key]
        public int OrgId { set; get; }
        public string OrgName { set; get; }
        public int OrgTypeId { set; get; }
        public DateTime? CreatedDate { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public bool? IsDeleted { set; get; }
        public int? CreatedBy { set; get; }
    }
}
