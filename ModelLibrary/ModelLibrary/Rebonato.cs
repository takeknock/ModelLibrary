using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class Rebonato
    {
        public double getCapletVolatility(double expiry, double a, double b, double c, double d)
        {

            double term1 = calculateTerm1(expiry, a, c, d);

            double term2 = calculateTerm2(expiry, a, b, c, d);

            double term3 = calculateTerm3(expiry, b, c);

            double varianceExpiry = calculateVolatility(expiry, c, term1, term2, term3);

            double initial = 0.0;

            double term1ForInitial = calculateTerm1(initial, a, c, d);
            double term2ForInitial = calculateTerm2(initial, a, b, c, d);
            double term3ForInitial = calculateTerm3(initial, b, c);

            double varianceInitial = calculateVolatility(initial, c, term1ForInitial, term2ForInitial, term3ForInitial);

            double variance = varianceExpiry - varianceInitial;
            double volatility = variance / expiry;

            return volatility;
        }


        private double calculateTerm1(double expiry, double a, double c, double d)
        {
            double term1 = -2.0 * c * c
                * (a * a + 4.0 * a * d * Math.Exp(c * expiry) 
                    - 2.0 * c * d * d * expiry * Math.Exp(c * expiry) * Math.Exp(c * expiry));
            return term1;
        }

        private double calculateTerm2(double expiry, double a, double b, double c, double d)
        {
            double term2 = 2.0 * b * c * (2.0 * a * c * expiry + a + 4.0 * d * Math.Exp(c * expiry) * (c * expiry + 1.0));
            return term2;
        }

        private double calculateTerm3(double expiry, double b, double c)
        {
            double term3 = b * b * (-(2.0 * c * c * expiry * expiry + 2.0 * c * expiry + 1.0));
            return term3;
        }

        private double calculateVolatility(double expiry, double c, double term1, double term2, double term3)
        {
            double volatility = 1.0 / (4.0 * c * c * c) * Math.Exp(-c * expiry) * Math.Exp(-c * expiry)
                * (term1 - term2 + term3);

            return volatility;
        }

    }
}
