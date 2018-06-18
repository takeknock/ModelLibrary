using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RootFinding;

namespace RootFindingTest
{
    [TestClass]
    public class UnitTest1
    {
        double quadraticTestFunction(double x)
        {
            return x * x + 3.0 * x - 4.0;
        }

        [TestMethod]
        public void TestMethod1()
        {
            // test
            //double x = 1.0;
            //const double expectedRight = 4.0;
            //const double expectedLeft = -1.0;

            //Bisect bisect = new Bisect(quadraticTestFunction, 14.0);
            //bisect.solve();
            //double actual = bisect.Answer;
        }
    }
}
