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
        TrapezoidApproximation integral = new TrapezoidApproximation();

        public double normalDistribution(double x)
        {
            Func<double, double> f = e =>
            {
                return normalDistProbabilityDensity(e);
            };

            const int partition = 10000000;
            double result = integral.integrate(-100000, x, partition, f);

            return result;
        }

        private double normalDistProbabilityDensity(double x)
        {
            return Math.Exp(- 0.5 * x * x) / Math.Sqrt(2.0 * Math.PI);

        }
    }
}
