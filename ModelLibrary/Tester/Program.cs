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
            double strike = 100.0;
            double maturity = 1.0;
            double interestRate = 0.2;

            double alpha = 0.1;
            double beta = 0.02;
            double nu = 0.1;
            double rho = 0.5;

            double actual = model.calculateHaganLogNormalApproxVol(strike, maturity, interestRate, alpha, beta, nu, rho);
            //Console.WriteLine(actual);

            double volatility = 0.2;
            double spot = 100;
            double payment = 90.0;
            CashDigital cashDigital = new CashDigital(strike, 1, payment);
            Lognormal lognormal = new ModelLibrary.diffusion.Lognormal();
            double cashDigitalPrice = lognormal.evaluate(cashDigital, interestRate, spot, volatility);
            Console.WriteLine("cash digital option price : " + cashDigitalPrice.ToString());
        }
    }
}
