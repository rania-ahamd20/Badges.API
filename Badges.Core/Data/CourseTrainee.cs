using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class CourseTrainee
    {
        public decimal Ctid { get; set; }
        public decimal? Mark { get; set; }
        public decimal? FkCourseid { get; set; }
        public decimal? FkUserid { get; set; }

        public virtual Course? FkCourse { get; set; }
        public virtual User? FkUser { get; set; }
    }
}
