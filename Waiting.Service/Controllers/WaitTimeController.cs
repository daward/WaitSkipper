using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Waiting.Service.Model;

namespace Waiting.Service.Controllers
{
    [RoutePrefix("wait")]
    public class WaitTimeController : ApiController
    {
        private readonly IWaitManager waitManager;

        public WaitTimeController(IWaitManager waitManager)
        {
            this.waitManager = waitManager;
        }

        [HttpPost]
        [Route("{locationId}")]
        public string PostWait(string locationId, [FromBody]Predicted predicted)
        {
            return waitManager.RecordPredictedWait(locationId, 
                predicted.MinimumWait,
                predicted.MaximumWait,
                predicted.LocalTime);
        }

        [HttpPost]
        [Route("actual/{locationId}/{waitId}")]
        public string PostWait(string locationId,
            string waitId,
            [FromBody]Actual actualWait)
        {
            return waitManager.UpdateWithActualWait(
                locationId, 
                waitId, 
                actualWait.ActualWait,
                actualWait.LocalTime);
        }

        [HttpPost]
        [Route("actual/{locationId}")]
        public string PostWait(string locationId, [FromBody]Actual actualWait)
        {
            return waitManager.RecordActualWait(
                locationId, 
                actualWait.ActualWait,
                actualWait.LocalTime);
        }
    }
}
