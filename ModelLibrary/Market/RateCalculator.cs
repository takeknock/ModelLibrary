using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumConst;

namespace Market
{
    public class RateCalculator
    {
        public double calculateForwardRate(
            double startDf, double endDf, double dayCountFraction)
        {
            double forwardRate = 
                (startDf / endDf - 1.0)
                / dayCountFraction;
            return forwardRate;
        }
        public double calculateDiscountFactor(ZeroRate rate, TimeSpan target)
        {
            double dayCountFraction = calcDayCountFraction(target, rate.Dcc);
            return Math.Exp(-rate.Value * target.Days);
        }

        private double calcDayCountFraction(TimeSpan target, DayCountConvention dcc)
        {
            DayCountManager mgr = new DayCountManager();
            return mgr.calculateDcf(target, dcc);
        }
    }
}
