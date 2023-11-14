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

    }
}
