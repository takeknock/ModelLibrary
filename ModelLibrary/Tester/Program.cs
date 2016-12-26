using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;
using ModelLibrary.diffusion;
using Contract.DigitalOption;


namespace Tester
{
    class Program
    {
        static void Main(string[] args)
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
            //Console.WriteLine(actual);

            decimal volatility = 0.2;
            decimal spot = 100;
            decimal payment = 90.0;
            CashDigital cashDigital = new CashDigital(strike, maturity, payment);
            Lognormal lognormal = new ModelLibrary.diffusion.Lognormal();
            decimal cashDigitalPrice = lognormal.evaluate(cashDigital, interestRate, spot, volatility);
            Console.WriteLine("cash digital option price : " + cashDigitalPrice.ToString());


            AssetDigital assetDigital = new AssetDigital(strike, maturity);
            decimal assetDigitalPrice = lognormal.evaluate(assetDigital, interestRate, spot, volatility);
            Console.WriteLine("asset digital option price : " + assetDigitalPrice.ToString());
        }
    }
}
