using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public class Cash
    {
        private double mid_;
        private DateTime startDate_;
        private DateTime endDate_;
        private EnumConst.DayCountConvention dcc;
        private EnumConst.BusinessDayConvention bdc;
        private Tenor tenor;

        public Cash(double mid, DateTime start, DateTime end)
        {
            this.mid = mid;
            startDate = start;
            endDate = end;
        }
    
        public double mid
        {
            get { return mid_; }
            private set { mid_ = value; }
        }

        public DateTime startDate
        {
            get { return startDate_; }
            private set { startDate_ = value; }
        }

        public DateTime endDate
        {
            get { return endDate_; }
            private set { endDate_ = value; }
        }

    }
}
