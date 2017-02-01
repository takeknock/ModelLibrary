using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.MonteCarlo
{
    static class LognormalImpl
    {
        static public double calculateNextStep(double thisStep, double drift, double dt, double volatility, double randomness)
        {
            return thisStep + drift * dt + volatility * Math.Sqrt(dt) * randomness;

        }
    }
}
