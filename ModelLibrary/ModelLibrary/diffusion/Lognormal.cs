using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.DigitalOption;
using Utility;
using System.Windows.Forms.DataVisualization.Charting;

namespace ModelLibrary.diffusion
{
    public class Lognormal : IDissution
    {
        //private Func<decimal, decimal> normalDistribution = 
        //    x =>
        //    {
        //        Chart chart = new Chart();
        //        return chart.DataManipulator.Statistics.NormalDistribution(x);
        //    };
        private NormalDisribution normDist = new NormalDisribution();
        
        public Lognormal()
        {
        }

        public decimal evaluate(IDigitalOption digitalOption)
        {
            return 0.0;
        }

        public decimal evaluate(CashDigital digital, decimal interestRate, decimal spot, decimal volatility, decimal dividend = 0.0)
        {
            // assume that the followings are constant
            // interestRate
            // volatility

            decimal d =
                //calculateNormalistributedVariable(
                //digital._strike, digital._maturity, spot, interestRate, dividend, volatility);
                (Math.Log(digital._strike / spot) - (interestRate - dividend - 0.5 * volatility * volatility) * digital._maturity)
                / (volatility * Math.Sqrt(digital._maturity));

            return digital._paymentValue * Math.Exp(-interestRate * digital._maturity) * normDist.normalDistribution(d);
        }

        public decimal evaluate(AssetDigital digital, decimal interestRate, decimal spot, decimal volatility, decimal dividend = 0.0)
        {

            decimal d = calculateNormalistributedVariable(
                    digital._strike, digital._maturity, spot, interestRate, dividend, volatility) 
                    + volatility * Math.Sqrt(digital._maturity);
            decimal price = spot * Math.Exp(-interestRate * digital._maturity) * normDist.normalDistribution(d);
            return price;
        }

        private decimal calculateNormalistributedVariable(
            decimal strike, decimal maturity, decimal spot, decimal interestRate, decimal dividend, decimal volatility)
        {
            decimal normalDistributed =
                (Math.Log(strike / spot) - (interestRate - dividend - 0.5 * volatility * volatility) * maturity)
                / (volatility * Math.Sqrt(maturity));
            return normalDistributed;
        }
    }
}
