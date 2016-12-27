using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Integration
{
    public class RectangleApproximation
    {
        public delegate double integratedFunction(double x);



        public double integrate(double start, double end, int numberOfPartition, integratedFunction f)
        {
            double h = (end - start) / numberOfPartition;
            double area = 0.0;
            for (int i = 0; i < numberOfPartition; ++i)
            {
                area += f(start) * h;
                start += h;
            }
            return area;
        }
    }
}   
