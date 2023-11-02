using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class AppliedUser
    {
        public int Aufjkey { get; set; }
        public int AccountKey { get; set; }
        public int PostKey { get; set; }
        public int CvFileKey { get; set; }

        public virtual Account AccountKeyNavigation { get; set; } = null!;
        public virtual Cvfile CvFileKeyNavigation { get; set; } = null!;
        public virtual Post PostKeyNavigation { get; set; } = null!;
    }
}
