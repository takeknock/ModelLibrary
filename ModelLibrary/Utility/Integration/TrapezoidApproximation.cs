using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Integration
{
    public class TrapezoidApproximation
    {
        public delegate double integratedFunction(double x);

        public double integrate(double start, double end, int numberOfPartition, Func<double, double> f)
        {
            double h = (end - start) / numberOfPartition;
            double area = 0.0;
            double next = start + h;

            for (int i = 1; i < numberOfPartition; ++i)
            {
                
                area += 0.5 * h * (f(start) + f(next));
                start += h;
                next += h;

            }

            return area;
        }
    }
}
