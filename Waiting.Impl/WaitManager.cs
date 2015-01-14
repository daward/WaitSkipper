using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiting.Repository;

namespace Waiting.Impl
{
    public class WaitManager : IWaitManager
    {
        private readonly IWaitRepository waitRepository;

        public WaitManager(IWaitRepository waitRepository)
        {
            this.waitRepository = waitRepository;
        }

        public string RecordPredictedWait(string locationId, int minimumWait, int maximumWait, DateTime localTime)
        {
            return waitRepository.RecordWait(new WaitTime
            {
                MinimumWait = minimumWait,
                MaximumWait = maximumWait,
                LocalTime = localTime,
                LocationId = locationId
            });
        }

        public string UpdateWithActualWait(string locationId, string waitId, int actualWait, DateTime localTime)
        {
            waitRepository.UpdateWait(waitId, 
                new WaitTime
            {
                ActualWait = actualWait,
                LocalTime = localTime,
                LocationId = locationId
            });

            return waitId;
        }

        public string RecordActualWait(string locationId, int actualWait, DateTime localTime)
        {
            return waitRepository.RecordWait(new WaitTime
            {
                ActualWait = actualWait,
                LocalTime = localTime,
                LocationId = locationId
            });
        }
    }
}
