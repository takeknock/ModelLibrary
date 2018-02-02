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
            List<Depo> cashList = createCashList();
            DateTime asof = new DateTime(20180101);
            YieldCurve yc = new YieldCurve(asof, cashList);
            yc.build();
            double actual = yc.df(new DateTime(20180201));
            double expected = 0.5;
            Assert.AreEqual(expected, actual, 10E-14);
        }

        private List<Depo> createCashList()
        {
            Depo c = new Depo(1.0, new DateTime(20180101), new DateTime(20180201));
            List<Depo> cashList = new List<Depo>();
            cashList.Add(c);
            return new List<Depo>(cashList);
        }
    }
}
