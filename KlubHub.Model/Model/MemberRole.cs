namespace KlubHub.Model
{
    public class MemberRole
    {
        public int Id { get; set; }
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
    }
}
