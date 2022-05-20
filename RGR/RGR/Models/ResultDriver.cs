using System;
using System.Collections.Generic;

namespace RGR
{
    public partial class ResultDriver
    {
        public string PosId { get; set; } = null!;
        public long? NumDriver { get; set; }
        public string? NameTrack { get; set; }
        public string? Time { get; set; }
        public string? Interval { get; set; }
        public string? KpH { get; set; }
        public string? Best { get; set; }
        public long? Laps { get; set; }

        public virtual Track? NameTrackNavigation { get; set; }
        public virtual Driver? NumDriverNavigation { get; set; }
    }
}
