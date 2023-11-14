using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class Assignment
    {
        public Assignment()
        {
            AssignmentsTrainees = new HashSet<AssignmentsTrainee>();
            Badges = new HashSet<Badge>();
        }

        public decimal Assignmentsid { get; set; }
        public DateTime? Datecreate { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Name { get; set; }
        public decimal? Mark { get; set; }
        public string? Description { get; set; }
        public decimal? FkCourseid { get; set; }

        public virtual Course? FkCourse { get; set; }
        public virtual ICollection<AssignmentsTrainee> AssignmentsTrainees { get; set; }
        public virtual ICollection<Badge> Badges { get; set; }
    }
}
