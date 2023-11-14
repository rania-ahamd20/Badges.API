using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class Course
    {
        public Course()
        {
            Assignments = new HashSet<Assignment>();
            Attendances = new HashSet<Attendance>();
            Badges = new HashSet<Badge>();
            CourseTrainees = new HashSet<CourseTrainee>();
        }

        public decimal Courseid { get; set; }
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }
        public string? Name { get; set; }
        public decimal? Duration { get; set; }
        public decimal? Sectionnum { get; set; }
        public string? Image { get; set; }
        public decimal? FkUserid { get; set; }
        public string? Coursenum { get; set; }
        public virtual User? FkUser { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Badge> Badges { get; set; }
        public virtual ICollection<CourseTrainee> CourseTrainees { get; set; }
    }
}
