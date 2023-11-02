using System;
using System.Collections.Generic;

namespace Entities.EntitiesDto
{
    public partial class AppliedAndCaredDto
    {
        public int Aacjkey { get; set; }
        public int AccountKey { get; set; }
        public int PostKey { get; set; }
        public string Status { get; set; } = null!;
    }
}
