using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiting.Repository
{
    public interface IWaitRepository
    {
        string RecordWait(WaitTime wait);

        void UpdateWait(string waitId, WaitTime wait);
    }
}
