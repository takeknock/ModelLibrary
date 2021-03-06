﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.DigitalOption;
using Contract;
using Utility;
using System.Windows.Forms.DataVisualization.Charting;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using ModelLibrary.MonteCarlo.Discretization;

namespace ModelLibrary.diffusion
{
    public class Lognormal : IDiffusion
    {

        //private Func<double, double> normalDistribution = 
        //    x =>
        //    {
        //        Chart chart = new Chart();
        //        return chart.DataManipulator.Statistics.NormalDistribution(x);
        //    };
        private NormalDisribution normDist = new NormalDisribution();


        public Lognormal()
        {
        }

        public double calculatePrice(IDigitalOption digitalOption)
        {
            return 0.0;
        }
        
        public double calculatePrice(CashDigital digital, double interestRate, double spot, double volatility, double dividend = 0.0)
        {
            // assume that the followings are constant
            // interestRate
            // volatility

            double d =
                //calculateNormalistributedVariable(
                //digital._strike, digital._maturity, spot, interestRate, dividend, volatility);
                (Math.Log(digital._strike / spot) - (interestRate - dividend - 0.5 * volatility * volatility) * digital._maturity)
                / (volatility * Math.Sqrt(digital._maturity));

            return digital._paymentValue * Math.Exp(-interestRate * digital._maturity) * normDist.cumulativeDensityFuntion(d);
        }

        public double calculatePrice(AssetDigital digital, double interestRate, double spot, double volatility, double dividend = 0.0)
        {

            double d = calculateStandardNormaldistributedVariable(
                    digital._strike, digital._maturity, spot, interestRate, dividend, volatility) 
                    + volatility * Math.Sqrt(digital._maturity);
            double price = spot * Math.Exp(-interestRate * digital._maturity) * normDist.cumulativeDensityFuntion(d);
            return price;
        }

        public double calculatePrice(
            PowerOption powerOption, double interestRate, double underlying, double volatility, double dividend = 0.0)
        {
            NormalDisribution n = new NormalDisribution();
            double d = (Math.Log(underlying / powerOption._strike) +
                    (interestRate - dividend - 0.5 * volatility * volatility) * powerOption._maturity)
                / (volatility * powerOption._maturity);
            double discountFactor = Math.Exp(-interestRate * powerOption._maturity);
            double expectation = Math.Pow(underlying, powerOption._exponent)
                * Math.Exp(powerOption._exponent
                    * (interestRate - dividend
                        + 0.5 * (powerOption._exponent - 1.0) * volatility * volatility)
                        * powerOption._maturity)
                * n.cumulativeDensityFuntion(d + powerOption._exponent * volatility * powerOption._maturity)
                - Math.Pow(powerOption._strike, powerOption._exponent) * n.cumulativeDensityFuntion(d);
            double price = discountFactor * expectation;
            return price;

        }

        public double calculatePremium(
            CashOnDeliveryOption contract, double underlying, double interestRate, 
            double volatility, double dividend = 0.0)
        {
            NormalDisribution n = new NormalDisribution();
            double d = calculateStandardNormaldistributedVariable(
                contract._strike, contract._maturity, underlying, interestRate, dividend, volatility);
            double premium = underlying * Math.Exp(interestRate - dividend) * contract._maturity
                * n.cumulativeDensityFuntion(d + volatility * contract._maturity) / n.cumulativeDensityFuntion(d)
                - contract._strike;

            return premium;
        }

        public double calculatePrice(PlainVanillaOption contract, double underlying, double interestRate, 
            double volatility, double dividend = 0.0)
        {
            NormalDisribution n = new NormalDisribution();
            double d1 = (Math.Log(contract._strike / underlying) 
                    + (interestRate - dividend - 0.5 * volatility * volatility * Math.Sqrt(contract._maturity)))
                / (volatility * Math.Sqrt(contract._maturity));
            double discountFactor = Math.Exp(-interestRate * contract._maturity);
            double d2 = (Math.Log(contract._strike / underlying) 
                    + (interestRate - dividend + 0.5 * volatility * volatility * Math.Sqrt(contract._maturity)))
                / (volatility * Math.Sqrt(contract._maturity));

            double price = discountFactor * (underlying * n.cumulativeDensityFuntion(d2)
                    - contract._strike * n.cumulativeDensityFuntion(d1));
            return price;
        }

        public double calculatePriceWithMC(PlainVanillaOption contract, double underlying, double interestRate,
            double volatility, int numberOfPaths, int numberOfDiscretization, double dividend = 0.0)
        {
            EulerMaruyama discretizer = new EulerMaruyama();
            MonteCarlo.MonteCarloRunner runner = new MonteCarlo.MonteCarloRunner(numberOfPaths, numberOfDiscretization, discretizer);
            double price = runner.calculatePrice(
                contract, underlying, interestRate, volatility);

            return price;

        }

        private double calculateStandardNormaldistributedVariable(
            double strike, double maturity, double spot, double interestRate, double dividend, double volatility)
        {
            double normalDistributed =
                (Math.Log(strike / spot) - (interestRate - dividend - 0.5 * volatility * volatility) * maturity)
                / (volatility * Math.Sqrt(maturity));
            return normalDistributed;
        }

        public double black(double volatility, double interestRate, double maturity, double strike, double forward)
        {
            if (volatility <= 0)
                throw new NotSupportedException("volatility must be positive.");
            NormalDisribution n = new NormalDisribution();
            double d1 = calculateD1(forward, strike, maturity, interestRate, volatility);
            double d2 = d1 - 0.5 * volatility * Math.Sqrt(maturity);
            return forward * n.cumulativeDensityFuntion(d1) 
                - strike * Math.Exp(- interestRate * maturity) * n.cumulativeDensityFuntion(d2);
        }

        private double calculateD1(double forward, double strike, double maturity, double interestRate, double volatility)
        {
            return (Math.Log(forward / strike) + (interestRate + 0.5 * volatility * volatility) * maturity)
                / (volatility * Math.Sqrt(maturity));

        }
       
        public double calculateBlackScholesMertonVega(double forward, double strike, double maturity, double interestRate, double volatility)
        {
            NormalDisribution n = new NormalDisribution();
            double d1 = calculateD1(forward, strike, maturity, interestRate, volatility);
            double vega = forward * n.cumulativeDensityFuntion(d1) * Math.Sqrt(maturity);
            return vega;
        }

        public double calculateImpliedVolatility(double forward, double strike, double maturity, double interestRate, double premium, double start, int numberOfIteration = 100, double tolerance = 10E-9)
        {
            double estimatedVolatility = start;
            for (int i = 0; i < numberOfIteration; ++i)
            {
                double diff = (black(forward, strike, maturity, interestRate, estimatedVolatility) - premium)
                    / calculateBlackScholesMertonVega(forward, strike, maturity, interestRate, estimatedVolatility);

                if (diff < tolerance)
                    break;
                estimatedVolatility -= diff;
            }

            return estimatedVolatility;
        }
    }
}
