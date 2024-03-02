using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlubHub.Model
{
    public class UserVM
    {
        public string? UserId { get; set; }
        public string? UserFullName { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
        public string? UserRole { get; set; }
        public string? Token { get; set; }
    }
}
