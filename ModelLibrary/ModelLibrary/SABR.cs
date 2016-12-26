using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public class SABR
    {
        private const decimal _tolerance = 10E-10;
        public decimal calculateHaganLogNormalApproxVol(decimal strike, decimal maturity, decimal forwardRate, decimal alpha, decimal beta, decimal nu, decimal rho)
        {
            decimal impliedVolatility = 0.0;
            if (isEqual(forwardRate, strike, _tolerance))
            {
                // ATM
                impliedVolatility = alpha / Math.Pow(forwardRate, (1.0 - beta))
                    * (1.0 + (1.0 - beta) * (1.0 - beta) / 24.0 * alpha * alpha / Math.Pow(forwardRate, (2.0 - 2.0 * beta)) * maturity
                        + 0.25 * rho * beta * nu * alpha / Math.Pow(forwardRate, 1.0 - beta) * maturity
                        + (2.0 - 3.0 * rho * rho) / 24.0 * nu * nu * maturity);
            }
            else
            {
                // except ATM
                // prepare to calculate Black implied log normal volatility

                decimal z = nu / alpha * Math.Pow((strike * forwardRate), 0.5 * (1.0 - beta))
                    * Math.Log(forwardRate / strike);

                decimal xi = Math.Log((Math.Sqrt(1.0 - 2.0 * rho * z + z * z) + z - rho) / (1.0 - rho));


                impliedVolatility = (alpha / (Math.Pow((strike * forwardRate), 0.5 * (1.0 - beta))
                        * (1.0 + (1.0 - beta) * (1.0 - beta) / 24.0 * Math.Log(forwardRate / strike) + Math.Pow((1.0 - beta), 4) / 1920.0
                            * Math.Log(forwardRate / strike))))
                    * (z / xi)
                    * (1.0 + (1.0 - beta) * (1.0 - beta) / 24.0 * alpha * alpha / Math.Pow((strike * forwardRate), 1 - beta) * maturity
                        + 0.25 * alpha * beta * rho * nu / Math.Pow((strike * forwardRate), 0.5 * (1.0 - beta)) * maturity
                        + (2.0 - 3.0 * rho * rho) / 24.0 * nu * nu * maturity);
            }

            return impliedVolatility;
        }

        private bool isEqual(decimal x, decimal y, decimal tolerance)
        {
            return Math.Abs(x - y) < tolerance;
        }

    }
}
