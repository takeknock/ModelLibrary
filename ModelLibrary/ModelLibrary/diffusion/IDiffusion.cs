﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.DigitalOption;

namespace ModelLibrary.diffusion
{
    interface IDiffusion
    {
        double calculatePrice(IDigitalOption digitalOption);
    }
}
