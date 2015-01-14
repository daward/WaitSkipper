using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace Waiting.Repository
{
    public class WaitRepository : IWaitRepository
    {
        private readonly DynamoDBContext context;

        public WaitRepository(DynamoDBContext context)
        {
            AutoMapperConfig.Configure();
            this.context = context;
        }

        public string RecordWait(WaitTime wait)
        {
            DynamoWait waitTime = Mapper.Map<DynamoWait>(wait);
            Guid retVal = Guid.NewGuid();
            waitTime.Id = retVal.ToString();
            context.Save<DynamoWait>(waitTime);

            return retVal.ToString();
        }

        public void UpdateWait(string waitId, WaitTime wait)
        {
        }
    }
}
