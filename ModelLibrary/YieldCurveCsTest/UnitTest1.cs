using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Market;
using System.Collections.Generic;
using YieldCurveCs;

namespace YieldCurveCsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void createYc()
        {
            List<Cash> cashList = createCashList();
            DateTime asof = new DateTime(20180101);
            YieldCurve yc = new YieldCurve(asof, cashList);
            yc.build();
            double actual = yc.df(new DateTime(20180201));
            double expected = 0.5;
            Assert.AreEqual(expected, actual, 10E-14);
        }

        private List<Cash> createCashList()
        {
            Cash c = new Cash(1.0, new DateTime(20180101), new DateTime(20180201));
            List<Cash> cashList = new List<Cash>();
            cashList.Add(c);
            return new List<Cash>(cashList);
        }
    }
}
