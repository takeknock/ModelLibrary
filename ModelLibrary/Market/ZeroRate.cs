using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumConst;

namespace Market
{
    public class ZeroRate
    {
        private double value;
        private DayCountConvention dcc;

        public ZeroRate(double rate, DayCountConvention dcc)
        {
            Value = rate;
            Dcc = dcc;
        }

        public double Value
        {
            get { return value; }
            private set { this.value = value; }
        }
        
        public DayCountConvention Dcc
        {
            get { return dcc; }
            private set { dcc = value; }
        }
    }
}
