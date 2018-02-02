using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Market;
using System.Collections.Generic;
using YieldCurveCs;
using EnumConst;

namespace YieldCurveCsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void check6mDf()
        {
            List<Depo> cashList = createCashList();
            List<SwapRate> swapList = createSwapList();
            DateTime asof = DateTime.Parse("2018/1/1");
            YieldCurve yc = new YieldCurve(asof, cashList, swapList);
            yc.build();
            DateTime target = asof.AddMonths(6);
            double actual = yc.df(target);
            double expected = 0.5;
            Assert.AreEqual(expected, actual, 10E-14);
        }

        [TestMethod]
        public void check1yDf()
        {
            List<Depo> cashList = createCashList();
            List<SwapRate> swapList = createSwapList();
            DateTime asof = DateTime.Parse("2018/1/1");
            YieldCurve yc = new YieldCurve(asof, cashList, swapList);
            yc.build();
            DateTime target = asof.AddYears(1);
            DateTime half = asof.AddMonths(6);
            double actual = yc.df(target);
            double expected = 1.0 / (0.5 * 0.1) - yc.df(half) * 0.5 / 0.5;
            Assert.AreEqual(expected, actual, 10E-5);
        }

        private List<Depo> createCashList()
        {
            DateTime start = DateTime.Parse("2018/1/1");
            DateTime end = start.AddMonths(6);
            Depo c = new Depo(1.0, start, end);
            List<Depo> cashList = new List<Depo>();
            cashList.Add(c);
            return new List<Depo>(cashList);
        }

        private List<SwapRate> createSwapList()
        {
            SwapRate s = new SwapRate(Tenor.OneYear, 0.1);
            List<SwapRate> swapList = new List<SwapRate>();
            swapList.Add(s);
            return new List<SwapRate>(swapList);
        }
    }
}
