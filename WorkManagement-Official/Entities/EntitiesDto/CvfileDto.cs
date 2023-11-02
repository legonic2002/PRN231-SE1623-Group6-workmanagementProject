using System;
using System.Collections.Generic;

namespace Entities.EntitiesDto
{
    public partial class CvfileDto
    {
        public int CvfileKey { get; set; }
        public int AccountKey { get; set; }
        public string CvName { get; set; } = null!;
        public string CvfileSource { get; set; } = null!;
    }
}
