using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Places.Request;
using GoogleMapsApi.Entities.Places.Response;
using GoogleMapsApi;

namespace Location.Google
{
    public class Places
    {
        private GoogleMapsApi.Entities.Common.Location location;
        private int distance;

        public Places(double latitude, double longitude, int distance)
        {
            this.location = new GoogleMapsApi.Entities.Common.Location(latitude, longitude);
            this.distance = distance;
        }

        public IEnumerable<Business> Businesses
        {
            get
            {
                var request = new PlacesRequest
                {
                    ApiKey = "AIzaSyDl-l6WPKq4jBlxsiWjRuTCCWvKc043vvw",
                    Location = location,
                    Radius = distance,
                    Types = "establishment"
                };
                PlacesResponse result = GoogleMaps.Places.Query(request);
                return result.Results.Select(x => new Business 
                { 
                    Id = x.ID + "#google", 
                    Name = x.Name, 
                    Latitude = x.Geometry.Location.Latitude, 
                    Longitude = x.Geometry.Location.Longitude
                });
            }
        }
    }
}
