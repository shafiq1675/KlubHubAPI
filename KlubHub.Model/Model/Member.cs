namespace KlubHub.Model
{
    public class Member
    {
        public int Id { get; set; }
        public string? UserFullName { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? ContactNumber {  get; set; }
        public string? Password { get; set; }
        public int? MemberRoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
    }
}
