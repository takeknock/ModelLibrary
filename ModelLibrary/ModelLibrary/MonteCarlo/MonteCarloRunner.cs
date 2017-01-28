using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Utility;

namespace ModelLibrary.MonteCarlo
{
    class MonteCarloRunner
    {
        public double calculatePrice(PlainVanillaOption contract, double underlying, double interestRate,
            double volatility, int numberOfPaths, int numberOfDiscretization, double dividend = 0.0)
        {
            double dt = contract._maturity / numberOfDiscretization;
            double drift = (interestRate - dividend - 0.5 * volatility * volatility);
            double logedUnderlying = Math.Log(underlying);
            BoxMuller rndGenerater = new BoxMuller(100);

            List<double> sum = new List<double>();
            for (int j = 1; j < numberOfPaths; ++j)
            {
                double thisLogedUnderlying = logedUnderlying;

                for (int i = 1; i < numberOfDiscretization; ++i)
                {
                    double randomness = rndGenerater.next();
                    thisLogedUnderlying += drift * dt + volatility * Math.Sqrt(dt) * randomness;
                }
                double underlyingAtMaturity = Math.Exp(thisLogedUnderlying);
                double cT = Math.Max(0.0, underlyingAtMaturity - contract._strike);
                sum.Add(cT);
            }
            double sumOfCT = sum.Select(i => i).Sum();
            double discountFactor = Math.Exp(-interestRate * contract._maturity);
            double price = sumOfCT / numberOfPaths * discountFactor;
            return price;
        }
    }
}
