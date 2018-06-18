using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumConst;

namespace Market
{
    public class Repo
    {
        private double bid_;
        private double offer_;
        private DateTime startDate_;
        private DateTime endDate_;
        private EnumConst.DayCountConvention dcc;
        private EnumConst.BusinessDayConvention bdc;
        private Tenor tenor;

        public Repo(double bid, double offer, DateTime start, DateTime end)
        {
            bid_ = bid;
            offer_ = offer;
            StartDate = start;
            EndDate = end;
        }
    
        public double Mid
        {
            get { return (bid_ + offer_) / 2.0; }
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
