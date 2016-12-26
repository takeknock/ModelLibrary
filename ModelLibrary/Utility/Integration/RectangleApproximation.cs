using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Integration
{
    public class RectangleApproximation
    {
        public delegate decimal integratedFunction(decimal x);



        public decimal integrate(decimal start, decimal end, int numberOfPartition, integratedFunction f)
        {
            decimal h = (end - start) / numberOfPartition;
            decimal area = 0.0;
            for (int i = 0; i < numberOfPartition; ++i)
            {
                area += f(start) * h;
                start += h;
            }
            return area;
        }
    }
}   
