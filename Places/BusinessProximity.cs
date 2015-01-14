using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Device.Location;

namespace Location
{
    public class BusinessProximity : IBusinessProximity
    {
        private readonly double distance;
        private readonly IBusiness business;

        public BusinessProximity(double distance, IBusiness business)
        {
            this.distance = distance;
            this.business = business;
        }

        public BusinessProximity(double latitude, double longitude, IBusiness business)
        {
            GeoCoordinate currentLocation = new GeoCoordinate(latitude, longitude);
            this.distance = currentLocation.GetDistanceTo(new GeoCoordinate(business.Latitude, business.Longitude));
            this.business = business;
        }

        public double Distance { get { return distance; } }

        public IBusiness Business { get { return business; } }
    }
}
