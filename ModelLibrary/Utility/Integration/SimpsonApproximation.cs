using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Integration
{
    public class SimpsonApproximation
    {
        public delegate double integratedFunction(double x);

        public double integrate(double start, double end, int numberOfPartition, Func<double, double> f)
        {
            double width = (end - start) / numberOfPartition;
            double area = 0.0;
            double next = start + width;

            for (int i = 0; i < numberOfPartition; ++i)
            {
                area += width * (f(start) + 4 * f(start + 0.5 * width) + f(next)) / 6.0;
                start += width;
                next += width;
            }

            return area;
        }
    }
}
