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
        public int _numberOfPaths { get; private set; }
        public int _numberOfDiscretization { get; private set; }
        private BoxMuller rndGenerator;

        public MonteCarloRunner(int numberOfPaths, int numberOfDiscretization, int? seed = null)
        {
            _numberOfPaths = numberOfPaths;
            _numberOfDiscretization = numberOfDiscretization;
            if (seed == null)
            {
                rndGenerator = new BoxMuller();
            }
            else
            {
                int intSeed = (int)seed;
                rndGenerator = new BoxMuller(intSeed);
            }
        }

        public double calculatePrice(PlainVanillaOption contract, double underlying, double interestRate,
            double volatility, double dividend = 0.0)
        {
            double dt = contract._maturity / _numberOfDiscretization;
            double drift = (interestRate - dividend - 0.5 * volatility * volatility);
            double logedUnderlying = Math.Log(underlying);
            BoxMuller rndGenerater = new BoxMuller();

            List<double> sum = new List<double>();
            for (int j = 1; j < _numberOfPaths; ++j)
            {
                double thisLogedUnderlying = logedUnderlying;

                for (int i = 1; i < _numberOfDiscretization; ++i)
                {
                    double randomness = rndGenerater.next();
                    thisLogedUnderlying = LognormalImpl.calculateNextStep(
                        thisLogedUnderlying, drift, dt, volatility, randomness);
                }
                double underlyingAtMaturity = Math.Exp(thisLogedUnderlying);
                double cT = Math.Max(0.0, underlyingAtMaturity - contract._strike);
                sum.Add(cT);
            }
            double sumOfCT = sum.Select(i => i).Sum();
            double discountFactor = Math.Exp(-interestRate * contract._maturity);
            double price = sumOfCT / _numberOfPaths * discountFactor;
            return price;
        }
    }
}
