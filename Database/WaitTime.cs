using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace Database
{
    [DynamoDBTable("WaitTime")]
    public class WaitTime
    {
        [DynamoDBHashKey]
        public int Id { get; set; }

        public int BusinessId { get; set; }

        public int PredictedMinutes { get; set; }

        public int ActualMinutes { get; set; }

        public DateTime Date { get; set; }
    }
}
