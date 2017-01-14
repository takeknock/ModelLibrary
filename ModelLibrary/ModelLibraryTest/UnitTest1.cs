using System;
using NUnit.Framework;
using ModelLibrary;
using ModelLibrary.diffusion;
using Contract;
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
            double price = lognormalDiffusion.calculatePrice(cashDigitalOption, interestRate, spot, volatility);
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
            double price = lognormalDiffusion.calculatePrice(assetDigitalOption, interestRate, spot, volatility);
            Assert.AreEqual(expected, price, thisTolerance);
        }

        [Test]
        public void testSpreadOptionEvaluation()
        {
            Normal normalDiffusion = new Normal();
            double strike = 100.0;
            double maturity = 1.0;
            double interestRate = 0.2;
            double volatility = 0.2;
            double spot = 100.0;

            SpreadOption contract = new SpreadOption(strike, maturity, true);
            double price = normalDiffusion.calculatePrice(contract, interestRate, volatility, spot);

            double expected = 0.0653252627335425;

            Assert.AreEqual(expected, price, tolerance);


        }

        [Test]
        public void testPowerOptionEvaluation()
        {
            Lognormal lognormalDiff = new Lognormal();
            double strike = 100.0;
            double maturity = 1.0;
            double interestRate = 0.2;
            double volatility = 0.2;
            double spot = 100.0;

            PowerOption contract = new PowerOption(strike, 2, maturity, true);
            double actual = lognormalDiff.calculatePrice(contract, interestRate, spot, volatility);

            double expected = 4801.622938787;

            Assert.AreEqual(expected, actual, tolerance);
        }

        [Test]
        public void testPlainVanillaOptionEvaluation()
        {
            Lognormal lognomalDiff = new Lognormal();
            double strike = 100.0;
            double maturity = 1.0;
            double interestRate = 0.2;
            double volatility = 0.2;
            double spot = 100.0;

            PlainVanillaOption callOption = new PlainVanillaOption(strike, maturity, true);
            double actual = lognomalDiff.calculatePrice(callOption, spot,interestRate, volatility);
            double expected = 3.96290578882745;

            Assert.AreEqual(expected, actual, tolerance);
        }
    }
}
