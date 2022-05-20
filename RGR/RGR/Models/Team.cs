using System;
using System.Collections.Generic;

namespace RGR
{
    public partial class Team
    {
        public Team()
        {
            Drivers = new HashSet<Driver>();
        }

        public string NameId { get; set; } = null!;
        public string? TrackName { get; set; }

        public virtual Track? TrackNameNavigation { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
