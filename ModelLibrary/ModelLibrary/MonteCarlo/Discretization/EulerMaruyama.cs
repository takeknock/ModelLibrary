using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.MonteCarlo.Discretization
{
    class EulerMaruyama : IDiscretizer
    {
        public EulerMaruyama()
        {
        }
        public double calculateNextStep(
            double thisStep, double drift,
            double dt, double volatility, double randomness)
        {
            return LognormalImpl.calculateNextStep(thisStep, drift, dt, volatility, randomness);
        }

    };
}

