using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;
using Utility;
using ModelLibrary.MonteCarlo.Discretization;

namespace ModelLibrary.MonteCarlo
{
    class MonteCarloRunner
    {
        public int _numberOfPaths { get; private set; }
        public int _numberOfDiscretization { get; private set; }
        private BoxMuller rndGenerator;
        private IDiscretizer _discretizer;

        public MonteCarloRunner(int numberOfPaths, int numberOfDiscretization, IDiscretizer discretizer, int? seed = null)
        {
            _numberOfPaths = numberOfPaths;
            _numberOfDiscretization = numberOfDiscretization;
            _discretizer = discretizer;
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
            double drift = LognormalImpl.calculateDrift(interestRate, volatility, dividend);
            double logedUnderlying = Math.Log(underlying);
            BoxMuller rndGenerater = new BoxMuller();

            List<double> sum = new List<double>();
            for (int j = 1; j < _numberOfPaths; ++j)
            {
                double thisLogedUnderlying = logedUnderlying;

                for (int i = 1; i < _numberOfDiscretization; ++i)
                {
                    double randomness = rndGenerater.next();
                    thisLogedUnderlying = _discretizer.calculateNextStep(
                            thisLogedUnderlying, drift, dt, volatility, randomness);
                }
                double underlyingAtMaturity = Math.Exp(thisLogedUnderlying);
                double cT = Math.Max(0.0, underlyingAtMaturity - contract._strike);
                sum.Add(cT);
            }
            double sumOfCT = sum.Select(i => i).Sum();
            double discountFactor = 
                LognormalImpl.calculateDiscountFactor(contract, interestRate);

            double price = sumOfCT / _numberOfPaths * discountFactor;
            return price;
        }
    }
}
