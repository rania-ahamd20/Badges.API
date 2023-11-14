﻿using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class AssignmentsTrainee
    {
        public decimal Atid { get; set; }
        public DateTime? Submitdate { get; set; }
        public decimal? Mark { get; set; }
        public decimal? FkAssignmentsid { get; set; }
        public decimal? FkUserid { get; set; }

        public virtual Assignment? FkAssignments { get; set; }
        public virtual User? FkUser { get; set; }
    }
}
