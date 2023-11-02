using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Post
    {
        public Post()
        {
            AppliedAndCareds = new HashSet<AppliedAndCared>();
            AppliedUsers = new HashSet<AppliedUser>();
        }

        public int PostKey { get; set; }
        public string Title { get; set; } 
        public int CompanyKey { get; set; }
        public DateTime ToTime { get; set; }
        public string SalaryType { get; set; }
        public int? Salary { get; set; }
        public int? SalaryFrom { get; set; }
        public int? SalaryTo { get; set; }
        public string WorkType { get; set; }
        public string Sex { get; set; } 
        public int Candidates { get; set; }
        public string Level { get; set; } 
        public string ExperienceType { get; set; }
        public int? Experience { get; set; }
        public int? ExperienceFrom { get; set; }
        public int? ExperienceTo { get; set; }
        public string Description { get; set; }
        public string RequiredCandicate { get; set; }
        public string Benefits { get; set; } 
        public string JobField { get; set; }

        public virtual Company CompanyKeyNavigation { get; set; } 
        public virtual ICollection<AppliedAndCared> AppliedAndCareds { get; set; }
        public virtual ICollection<AppliedUser> AppliedUsers { get; set; }
    }
}
