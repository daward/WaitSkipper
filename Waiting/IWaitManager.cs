using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiting
{
    public interface IWaitManager
    {
        string RecordPredictedWait(string locationId, int minimumWait, int maximumWait, DateTime localTime);

        string UpdateWithActualWait(string locationId, string waitId, int actualWait, DateTime localTime);

        string RecordActualWait(string locationId, int actualWait, DateTime localTime);
    }
}
