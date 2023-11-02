using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Company
    {
        public Company()
        {
            Accounts = new HashSet<Account>();
            Posts = new HashSet<Post>();
        }

        public int CompanyKey { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string WorkField { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
