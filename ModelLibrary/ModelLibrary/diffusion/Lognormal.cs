using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.DigitalOption;
using Utility;
using System.Windows.Forms.DataVisualization.Charting;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Appender;

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

        public double evaluate(IDigitalOption digitalOption)
        {
            return 0.0;
        }
        
        public double evaluate(CashDigital digital, double interestRate, double spot, double volatility, double dividend = 0.0)
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

        public double evaluate(AssetDigital digital, double interestRate, double spot, double volatility, double dividend = 0.0)
        {

            double d = calculateNormalistributedVariable(
                    digital._strike, digital._maturity, spot, interestRate, dividend, volatility) 
                    + volatility * Math.Sqrt(digital._maturity);
            double price = spot * Math.Exp(-interestRate * digital._maturity) * normDist.cumulativeDensityFuntion(d);
            return price;
        }

        private double calculateNormalistributedVariable(
            double strike, double maturity, double spot, double interestRate, double dividend, double volatility)
        {
            double normalDistributed =
                (Math.Log(strike / spot) - (interestRate - dividend - 0.5 * volatility * volatility) * maturity)
                / (volatility * Math.Sqrt(maturity));
            return normalDistributed;
        }
    }
}
