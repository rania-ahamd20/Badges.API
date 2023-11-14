using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class Attendance
    {
        public decimal Attendanceid { get; set; }
        public DateTime? Attendantedate { get; set; }
        public decimal? Numattendance { get; set; }
        public decimal? FkCourseid { get; set; }
        public decimal? FkUserid { get; set; }

        public virtual Course? FkCourse { get; set; }
        public virtual User? FkUser { get; set; }
    }
}
