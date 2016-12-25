using System;
using NUnit.Framework;
using ModelLibrary;
using ModelLibrary.diffusion;
using Contract.DigitalOption;

namespace ModelLibraryTest
{
    [TestFixture]
    public class UnitTest1
    {
        private double tolerance = 10E-10;
        [Test]
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

        [Test]
        public void testCashDigitalOptionEvaluation()
        {
            double thisTolerance = 10E-1;
            Lognormal lognormalDiffusion = new Lognormal();
            double strike = 100.0;
            double maturity = 1.0;
            double interestRate = 0.2;
            double volatility = 0.2;
            double spot = 100.0;
            double payment = 90.0;

            double expected = 13.5626091592514;

            CashDigital cashDigitalOption = new CashDigital(strike, maturity, payment);
            double price = lognormalDiffusion.evaluate(cashDigitalOption, interestRate, spot, volatility);
            Assert.AreEqual(expected, price, thisTolerance);
        }

        [Test]
        public void testAssetDigitalOptionEvaluation()
        {
            double thisTolerance = 10E-1;

            Lognormal lognormalDiffusion = new Lognormal();
            double strike = 100.0;
            double maturity = 1.0;
            double interestRate = 0.2;
            double volatility = 0.2;
            double spot = 100.0;

            double expected = 19.8103022569233;

            AssetDigital assetDigitalOption = new AssetDigital(strike, maturity);
            double price = lognormalDiffusion.evaluate(assetDigitalOption, interestRate, spot, volatility);
            Assert.AreEqual(expected, price, thisTolerance);
        }
    }
}
