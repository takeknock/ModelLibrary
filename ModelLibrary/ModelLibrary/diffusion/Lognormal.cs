using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.DigitalOption;
using System.Windows.Forms.DataVisualization.Charting;

namespace ModelLibrary.diffusion
{
    public class Lognormal : IDissution
    {
        private Func<double, double> normalDistribution = 
            x =>
            {
                Chart chart = new Chart();
                return chart.DataManipulator.Statistics.NormalDistribution(x);
            };

        public Lognormal()
        {

        }

        public double evaluate(IDigitalOption digitalOption)
        {
            return 0.0;
        }

        public double evaluate(CashDigital digital, double interestRate, double spot, double volatility, double dividend = 0.0)
        {
            //StatisticFormula formula = new StatisticFormula;
            //Chart chart = new Chart();

            double d =
                (Math.Log(digital._strike / spot) - (interestRate - dividend - 0.5 * volatility * volatility) * digital._maturity)
                / (volatility * Math.Sqrt(digital._maturity));

            return digital._paymentValue * Math.Exp(-interestRate * digital._maturity) * normalDistribution(d);
        }
    }
}
