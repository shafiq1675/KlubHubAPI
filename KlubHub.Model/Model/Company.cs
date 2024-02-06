using System.ComponentModel.DataAnnotations;

namespace KlubHub.Model
{
    public class Company
    {
        public string? Id { get; set; }
        public string? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
    }
}
