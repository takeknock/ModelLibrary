using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumConst;

namespace Market
{
    class Calculator
    {
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
