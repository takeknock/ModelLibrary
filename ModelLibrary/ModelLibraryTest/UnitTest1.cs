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
        private decimal tolerance = 10E-10;
        [Test]
        public void TestMethod1()
        {
            SABR model = new SABR();

            decimal strike = 100.0;
            decimal maturity = 1.0;
            decimal interestRate = 0.2;

            decimal alpha = 0.1;
            decimal beta = 0.02;
            decimal nu = 0.1;
            decimal rho = 0.5;

            decimal actual = model.calculateHaganLogNormalApproxVol(strike, maturity, interestRate, alpha, beta, nu, rho);

            decimal expected = 0.23074062844366;
            //decimal expected = 1;
            Assert.AreEqual(expected, actual, tolerance);

        }

        [Test]
        public void testCashDigitalOptionEvaluation()
        {
            decimal thisTolerance = 10E-1;
            Lognormal lognormalDiffusion = new Lognormal();
            decimal strike = 100.0;
            decimal maturity = 1.0;
            decimal interestRate = 0.2;
            decimal volatility = 0.2;
            decimal spot = 100.0;
            decimal payment = 90.0;

            decimal expected = 13.5626091592514;

            CashDigital cashDigitalOption = new CashDigital(strike, maturity, payment);
            decimal price = lognormalDiffusion.evaluate(cashDigitalOption, interestRate, spot, volatility);
            Assert.AreEqual(expected, price, thisTolerance);
        }

        [Test]
        public void testAssetDigitalOptionEvaluation()
        {
            decimal thisTolerance = 10E-1;

            Lognormal lognormalDiffusion = new Lognormal();
            decimal strike = 100.0;
            decimal maturity = 1.0;
            decimal interestRate = 0.2;
            decimal volatility = 0.2;
            decimal spot = 100.0;

            decimal expected = 19.8103022569233;

            AssetDigital assetDigitalOption = new AssetDigital(strike, maturity);
            decimal price = lognormalDiffusion.evaluate(assetDigitalOption, interestRate, spot, volatility);
            Assert.AreEqual(expected, price, thisTolerance);
        }
    }
}
