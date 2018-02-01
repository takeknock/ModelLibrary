using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market;

namespace YieldCurveCs
{
    public class YieldCurve
    {

        private List<Cash> cashList;
        private List<Tuple<DateTime, double>> dfs;
        private DateTime asof;

        public YieldCurve(DateTime asof, List<Cash> cash)
        {
            this.asof = asof;
            cashList = cash;
        }

        public void build()
        {
            bootstrap();
        }

        private void bootstrap()
        {
            dfs = cashList.Select(e => calculateDf(e)).ToList();
        }

        private Tuple<DateTime, double> calculateDf(Cash cash)
        {
            double mid = cash.mid;
            return new Tuple<DateTime, double>(cash.endDate, 1.0 / (1.0 + mid));
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
