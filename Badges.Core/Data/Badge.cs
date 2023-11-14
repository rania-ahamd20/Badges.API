using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class Badge
    {
        public decimal Badgesid { get; set; }
        public string? Type { get; set; }
        public string? Text { get; set; }
        public string? Image { get; set; }
        public decimal? FkAssignments { get; set; }
        public decimal? FkUserid { get; set; }
        public decimal? FkCourseid { get; set; }

        public virtual Assignment? FkAssignmentsNavigation { get; set; }
        public virtual Course? FkCourse { get; set; }
        public virtual User? FkUser { get; set; }
    }
}
