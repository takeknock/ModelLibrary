using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;

namespace ModelLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        private double tolerance = 10E-10;
        [TestMethod]
        public void TestMethod1()
        {
            SABR model = new SABR();

            double strike = 100.0;
            double maturity = 1.0;
            double interestRate = 0.2;

            double alpha = 0.1;
            double beta = 0.02;
            double nu = 0.1;
            double rho = 0.5;

            double actual = model.calculateHaganLogNormalApproxVol(strike, maturity, interestRate, alpha, beta, nu, rho);

            double expected = 0.23074062844366;
            //double expected = 1;
            Assert.AreEqual(expected, actual, tolerance);

        }
    }
}
