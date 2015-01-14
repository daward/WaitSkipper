using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location
{
    public interface IBusiness
    {
        string Id { get; set; }

        double Latitude { get; set; }

        double Longitude { get; set; }

        string Name { get; set; }
    }
}
