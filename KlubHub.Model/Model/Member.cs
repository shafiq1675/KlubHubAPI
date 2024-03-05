namespace KlubHub.Model
{
    public class Member
    {
        public int Id { get; set; }
        public string? MemberFullName { get; set; }
        public string? MemberUserName { get; set; }
        public string? MemberEmail { get; set; }
        public string? MemberContactNumber {  get; set; }
        public string? Password { get; set; }
        public int? MemberRoleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
    }
}
