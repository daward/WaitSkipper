using System.Collections.Generic;
using System.Linq;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using AutoMapper;

namespace Location.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DynamoDBContext context;

        public LocationRepository(DynamoDBContext context)
        {
            AutoMapperConfig.Configure();
            this.context = context;
        }

        public IEnumerable<IBusiness> SaveBusinesses(IEnumerable<IBusiness> businesses)
        {
            BatchWrite<Business> batch = context.CreateBatchWrite<Business>();
            batch.AddPutItems(Mapper.Map<List<Business>>(businesses));
            batch.Execute();
            return businesses;
        }

        public IEnumerable<IBusinessProximity> GetBusinesses(double latitude, double longitude, double boundingDegrees)
        {
            IEnumerable<Business> businesses = context.Scan<Business>(
                  new ScanCondition("Latitude", ScanOperator.LessThanOrEqual, latitude + boundingDegrees),
                  new ScanCondition("Latitude", ScanOperator.GreaterThanOrEqual, latitude - boundingDegrees),
                  new ScanCondition("Longitude", ScanOperator.LessThanOrEqual, longitude + boundingDegrees),
                  new ScanCondition("Longitude", ScanOperator.GreaterThanOrEqual, longitude - boundingDegrees)
                  );

            return businesses.Select(x => new BusinessProximity(latitude, longitude, x));
        }
    }
}
