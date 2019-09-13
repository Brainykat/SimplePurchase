using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Domain.Entities
{
    public class User //: IdentityUser
    {
        public Guid EmployeeId { get; set; }
        public DateTime RegisteredOn { get; set; }
        public string RegisterdBy { get; set; }
        public DateTime LastPasswordChange { get; set; }
        public DateTime LastSeen { get; set; }
        public bool DefaultPassChanged { get; set; }
        public DateTime? ExpirelyDate { get; set; }
        public bool IsRevoked { get; set; }
        public User User { get; set; }
    }
}
