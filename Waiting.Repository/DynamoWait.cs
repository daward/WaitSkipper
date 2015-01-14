using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Waiting.Repository
{
    [DynamoDBTable("WaitTime")]
    internal class DynamoWait
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        public int? ActualWait { get; set; }
        public int? MinimumWait { get; set; }
        public int? MaximumWait { get; set; }
        public DateTime LocalTime { get; set; }

        [DynamoDBRangeKey]
        public string LocationId { get; set; }
    }
}
