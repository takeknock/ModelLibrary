using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Adapter
{
    public class Class1
    {
        static void Main()
        {
            YieldCurve yc = new YieldCurve();
            yc.build();

            YieldCurveBuilder builder = new YieldCurveBuilder();
            yc = builder.createYieldCurve();
        }        
    }
}
