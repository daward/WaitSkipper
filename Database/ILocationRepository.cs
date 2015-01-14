using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location.Repository
{
    public interface ILocationRepository
    {
        IEnumerable<IBusiness> SaveBusinesses(IEnumerable<IBusiness> businesses);

        IEnumerable<IBusinessProximity> GetBusinesses(double latitude, double longitude, double boundingDegrees);
    }
}
