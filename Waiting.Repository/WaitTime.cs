using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiting.Repository
{
    public class WaitTime
    {
        public int? ActualWait { get; set; }
        public int? MinimumWait { get; set; }
        public int? MaximumWait { get; set; }
        public DateTime LocalTime { get; set; }
        public string LocationId { get; set; }
    }
}
