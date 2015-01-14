using System.Collections.Generic;
using System.Web.Http;
using Location;
using AutoMapper;

namespace Location.Service.Controllers
{
    [RoutePrefix("locations")]
    public class LocationsController : ApiController
    {
        private readonly IPlaceFetcher placeFetcher;

        public LocationsController(IPlaceFetcher placeFetcher)
        {
            AutoMapperConfig.Configure();

            this.placeFetcher = placeFetcher;
        }

        [HttpGet]
        [Route("{latitude}/{longitude}")]
        public IEnumerable<Service.Model.Business> Get(double latitude, double longitude)
        {
            return Mapper.Map<IEnumerable<Service.Model.Business>>(placeFetcher.GetPlaces(latitude, longitude));
        }
    }
}