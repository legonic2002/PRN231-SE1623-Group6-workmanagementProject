using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Cvfile
    {
        public Cvfile()
        {
            AppliedUsers = new HashSet<AppliedUser>();
        }

        public int CvfileKey { get; set; }
        public string Cvname { get; set; } = null!;
        public int AccountKey { get; set; }
        public string CvfileSource { get; set; } = null!;

        public virtual Account AccountKeyNavigation { get; set; } = null!;
        public virtual ICollection<AppliedUser> AppliedUsers { get; set; }
    }
}
