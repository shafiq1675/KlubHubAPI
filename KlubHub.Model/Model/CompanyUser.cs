namespace KlubHub.Model
{
    public class Member
    {
        public int Id { get; set; }

        public string? UserId { get; set; }
        public string? UserFullName { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
        public string? UserRole { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
    }
}
