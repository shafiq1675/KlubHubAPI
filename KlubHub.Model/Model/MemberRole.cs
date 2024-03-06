using System.ComponentModel.DataAnnotations;

namespace KlubHub.Model
{
    public class MemberRole
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
       
    }
}
