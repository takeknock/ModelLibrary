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
            if (System.Environment.Is64BitProcess)
            {
                Console.WriteLine("64ビットで動作しています");
            }
            //YieldCurve yc = new YieldCurve();
            //yc.build();

            //YieldCurveBuilder builder = new YieldCurveBuilder();
            //YieldCurve yc = builder.createYieldCurve();
        }        
    }
}
