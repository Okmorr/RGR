using System;
using System.Collections.Generic;

namespace RGR
{
    public partial class Driver
    {
        public Driver()
        {
            ResultDrivers = new HashSet<ResultDriver>();
        }

        public long NumId { get; set; }
        public string? Name { get; set; }

        public virtual Team? NameNavigation { get; set; }
        public virtual ICollection<ResultDriver> ResultDrivers { get; set; }
    }
}
