namespace KlubHub.Model
{
    public class UserRole
    {
        public int Id { get; set; }
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? CompanyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
    }
}
