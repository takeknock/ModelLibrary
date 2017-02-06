using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.MonteCarlo.Discretization
{
    interface IDiscretizer
    {
        double calculateNextStep(
            double underlying, double drift, 
            double dt, double volatility, double randomness);
    }
}
