using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Integration;

namespace Utility
{
    public class NormalDisribution
    {
        SimpsonApproximation integral = new SimpsonApproximation();

        public double cumulativeDensityFuntion(double x)
        {
            Func<double, double> f = e =>
            {
                return probabilityDensityFunction(e);
            };

            const int partition = 10000000;
            double result = integral.integrate(-100000, x, partition, f);

            return result;
        }

        public double probabilityDensityFunction(double x)
        {
            return Math.Exp(- 0.5 * x * x) / Math.Sqrt(2.0 * Math.PI);
        }


    }
}
