﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market;
using EnumConst;

namespace YieldCurveCs
{
    public class YieldCurve
    {
        private List<Repo> cashList;
        private List<SwapRate> swapList;
        private List<Tuple<DateTime, double>> dfs;
        private DateTime asof;

        public YieldCurve(DateTime asof, List<Repo> cash, List<SwapRate> swap)
        {
            this.asof = asof;
            cashList = cash;
            swapList = swap;
        }

        public double forwardRate(
            DateTime startDate, DateTime endDate, DayCountConvention dcc)
        {
            RateCalculator calc = new Market.RateCalculator();
            DayCountManager mgr = new DayCountManager();

            double dayCountFraction = mgr.calculateDcf(endDate - startDate, dcc);

            return calc.calculateForwardRate(
                df(startDate), df(endDate), dayCountFraction);
        }

        public void build()
        {
            bootstrap();
        }

        private void bootstrap()
        {
            dfs = cashList.Select(e => calculateDf(e)).ToList();
            Tuple<DateTime, double> half = dfs.Last();
            DayCountManager mgr = new DayCountManager();
            double halfDayCountFraction = 0.5;
            double df = calculateDf(swapList.ElementAt(0), halfDayCountFraction, half.Item2, halfDayCountFraction);
            Tuple<DateTime, double> oneYear = new Tuple<DateTime, double>(asof.AddYears(1), df);
            dfs.Add(oneYear);
        }

        private Tuple<DateTime, double> calculateDf(Repo cash)
        {
            double mid = cash.Mid;
            return new Tuple<DateTime, double>(cash.EndDate, 1.0 / (1.0 + mid));
        }

        private double calculateDf(SwapRate swap, double dcf_1y, double df_6m, double dcf_6m)
        {
            double df_1y = 1.0 / (dcf_1y * swap.Value) - df_6m * dcf_6m / dcf_1y;
            return df_1y;
        }

        public double df(DateTime target)
        {
            var list = dfs.Where(e => e.Item1 == target);
            if (list.Count() != 0)
            {
                return list.First().Item2;
            }
            Tuple<DateTime, double> formerDf = dfs.FindLast(e => e.Item1 < target);
            Tuple<DateTime, double> laterDf = dfs.Find(e => e.Item1 > target);
            var ret = interpolate(formerDf, laterDf, target);
            return ret.Item2;
            
        }

        private Tuple<DateTime, double> interpolate(
            Tuple<DateTime, double> former, 
            Tuple<DateTime, double> later, 
            DateTime target)
        {
            return linearInterpolate(former, later, target);
        }

        private Tuple<DateTime, double> linearInterpolate(
            Tuple<DateTime, double> former,
            Tuple<DateTime, double> later,
            DateTime target)
        {
            double a = (target - former.Item1).Days;
            double b = (later.Item1 - target).Days;
            double targetDf = former.Item2 + (later.Item2 - former.Item2) / (a + b) * a;
            return new Tuple<DateTime, double>(target, targetDf);
        }
    }
}
