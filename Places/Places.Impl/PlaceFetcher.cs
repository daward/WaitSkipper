using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location.Repository;

namespace Location.Impl
{
    public class PlaceFetcher : IPlaceFetcher
    {
        private static readonly int FetchSize = 200;
        private static readonly double BoundingSize = 0.002;
        private static readonly double LikelyCorrectDistanceMeters = 75;

        private readonly ILocationRepository locationRepository;

        public PlaceFetcher(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public IEnumerable<IBusinessProximity> GetPlaces(double latitude, double longitude)
        {
            //first search our known places
            IEnumerable<IBusinessProximity> businesses =
                locationRepository.GetBusinesses(latitude, longitude, BoundingSize);

            businesses = businesses.Where(x => (x.Distance <= LikelyCorrectDistanceMeters));

            //we probably don't need to requery because we have something very close
            if (businesses.Count() == 0)
            {
                //if not, go get more data from google and save it
                businesses = FetchMorePlaces(latitude, longitude).Where(x => (x.Distance <= LikelyCorrectDistanceMeters));  
            }

            return businesses.OrderBy(x => x.Distance).ToList();
        }

        private IEnumerable<IBusinessProximity> FetchMorePlaces(double latitude, double longitude)
        {
            Location.Google.Places places = new Location.Google.Places(latitude, longitude, FetchSize);

            IEnumerable<IBusiness> businesses = locationRepository.SaveBusinesses(places.Businesses);

            return businesses.Select(x => new BusinessProximity(latitude, longitude, x));
        }
    }
}
