using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public class Depo
    {
        private double mid_;
        private DateTime startDate_;
        private DateTime endDate_;
        private EnumConst.DayCountConvention dcc;
        private EnumConst.BusinessDayConvention bdc;
        private Tenor tenor;

        public Depo(double mid, DateTime start, DateTime end)
        {
            Mid = mid;
            StartDate = start;
            EndDate = end;
        }
    
        public double Mid
        {
            get { return mid_; }
            private set { mid_ = value; }
        }

        public DateTime StartDate
        {
            get { return startDate_; }
            private set { startDate_ = value; }
        }

        public DateTime EndDate
        {
            get { return endDate_; }
            private set { endDate_ = value; }
        }
    }
}
