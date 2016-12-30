using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    class Rebonato
    {

        private double calculateTerm1(double expiry, double a, double c, double d)
        {
            double term1 = -2.0 * c * c
                * (a * a + 4.0 * a * d * Math.Exp(c * expiry) 
                    - 2.0 * c * d * d * expiry * Math.Exp(c * expiry) * Math.Exp(c * expiry));
            return term1;
        }

        private double calculateTerm2(double expiry, double b, double c)
        {
            double term2 = 2.0 * b * c * (2.0 * a * c * expiry + a + 4.0 * d * Math.Exp(c * expiry) * (c * expiry + 1.0));
            return term2;
        }

        private double calculateTerm3(double expiry, double b, double c)
        {
            double term3 = b * b * (-(2.0 * c * c * expiry * expiry + 2.0 * c * expiry + 1.0));
            return term3;
        }


    }
}
