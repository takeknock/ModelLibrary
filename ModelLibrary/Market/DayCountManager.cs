using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumConst;

namespace Market
{
    public class DayCountManager
    {

        // various specific calculation with daycount convention
        public DayCountManager()
        {
        }

        public double calculateDcf(TimeSpan term, DayCountConvention dcc)
        {
            if (dcc == EnumConst.DayCountConvention.ACT_360)
            {
                return term.Days / 360;
            }
            else
            {
                return term.Days / 365;
            }
        }


    }
}
