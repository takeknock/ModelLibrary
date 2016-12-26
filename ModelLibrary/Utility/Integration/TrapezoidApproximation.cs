using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Integration
{
    public class TrapezoidApproximation
    {
        public delegate decimal integratedFunction(decimal x);

        public decimal integrate(decimal start, decimal end, int numberOfPartition, Func<decimal, decimal> f)
        {
            decimal h = (end - start) / numberOfPartition;
            decimal area = 0.0;
            decimal next = start + h;

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
