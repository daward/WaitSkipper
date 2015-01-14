using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiting.Service.Model
{
    public class Predicted
    {
        public int MinimumWait { get; set; }
        public int MaximumWait { get; set; }
        public DateTime LocalTime { get; set; }
    }
}
