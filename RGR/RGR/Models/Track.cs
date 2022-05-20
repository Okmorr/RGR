using System;
using System.Collections.Generic;

namespace RGR
{
    public partial class Track
    {
        public Track()
        {
            ResultDrivers = new HashSet<ResultDriver>();
            Teams = new HashSet<Team>();
        }

        public string NameId { get; set; } = null!;
        public long? Year { get; set; }
        public long? Lap { get; set; }

        public virtual Championship? YearNavigation { get; set; }
        public virtual ICollection<ResultDriver> ResultDrivers { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
