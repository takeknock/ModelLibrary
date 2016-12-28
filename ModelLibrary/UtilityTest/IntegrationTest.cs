using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Utility;

namespace UtilityTest
{
    [TestFixture]
    public class IntegrationTest
    {
        private double testFunction(double x)
        {
            return x * x * x + x * x + 1;
        }

        private double tolerance = 10E-10;
        private double easyTolerance = 10E-1;
        private double x = 5;



        [Test]
        public void testRectangleApproximation()
        {
            Utility.Integration.RectangleApproximation i = new Utility.Integration.RectangleApproximation();
            double expected = x * x * x * x / 4.0 + x * x * x / 3.0 + x;


            // integrate between 0 and 5

            double actual = i.integrate(0, 5, 1000, testFunction);
            
            Assert.AreEqual(expected, actual, easyTolerance);
        }

        [Test]
        public void testTrapezoidApproximation()
        {
            Utility.Integration.TrapezoidApproximation i = new Utility.Integration.TrapezoidApproximation();

            // integrate between 0 and 5
            double expected = x * x * x * x / 4.0 + x * x * x / 3.0 + x;

            double actual = i.integrate(0, 5, 1000, testFunction);

            Assert.AreEqual(expected, actual, easyTolerance);
        }

    }
}
