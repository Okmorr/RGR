using System;
using System.Collections.Generic;

namespace RGR
{
    public partial class Championship
    {
        public Championship()
        {
            Tracks = new HashSet<Track>();
        }

        public long YearId { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
