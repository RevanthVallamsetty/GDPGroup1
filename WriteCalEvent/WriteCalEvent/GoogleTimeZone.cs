using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WriteCalEvent
{
    public class GoogleTimeZone
    {
        public double dstOffset { get; set; }
        public double rawOffset { get; set; }
        public string status { get; set; }
        public string timeZoneId { get; set; }
        public string timeZoneName { get; set; }
    }
}