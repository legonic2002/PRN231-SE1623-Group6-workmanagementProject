using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class AppliedAndCared
    {
        public int Aacjkey { get; set; }
        public int AccountKey { get; set; }
        public int PostKey { get; set; }
        public string Status { get; set; } = null!;

        public virtual Account AccountKeyNavigation { get; set; } = null!;
        public virtual Post PostKeyNavigation { get; set; } = null!;
    }
}
