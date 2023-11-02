using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Account
    {
        public Account()
        {
            AppliedAndCareds = new HashSet<AppliedAndCared>();
            AppliedUsers = new HashSet<AppliedUser>();
            Cvfiles = new HashSet<Cvfile>();
        }

        public int AccountKey { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int? CompanyKey { get; set; }

        public virtual Company? CompanyKeyNavigation { get; set; }
        public virtual ICollection<AppliedAndCared> AppliedAndCareds { get; set; }
        public virtual ICollection<AppliedUser> AppliedUsers { get; set; }
        public virtual ICollection<Cvfile> Cvfiles { get; set; }
    }
}
