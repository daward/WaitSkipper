﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location
{
    public interface IBusinessProximity
    {
        double Distance { get; }

        IBusiness Business { get; }
    }
}
