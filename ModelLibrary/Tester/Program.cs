using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;
using ModelLibrary.diffusion;
using Contract.DigitalOption;
using Contract;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using Utility;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = Log.getLogger();
            logger.Info("=============================pricing start=============================");

            logger.Info("calculate volatility with SABR model.");

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

            logger.Info("calculate the price of cash digital option.");

            double volatility = 0.2;
            double spot = 100;
            double payment = 90.0;
            CashDigital cashDigital = new CashDigital(strike, maturity, payment);
            Lognormal lognormal = new ModelLibrary.diffusion.Lognormal();
            double cashDigitalPrice = lognormal.evaluate(cashDigital, interestRate, spot, volatility);
            Console.WriteLine("cash digital option price : " + cashDigitalPrice.ToString());

            logger.Info("calculate the price of asset digital option.");

            AssetDigital assetDigital = new AssetDigital(strike, maturity);
            double assetDigitalPrice = lognormal.evaluate(assetDigital, interestRate, spot, volatility);
            Console.WriteLine("asset digital option price : " + assetDigitalPrice.ToString());

            logger.Info("calculate volatility of caplet with Rebonato equation.");

            Rebonato reb = new Rebonato();
            double a = 0.2;
            double b = 0.1;
            double c = 0.3;
            double d = 0.5;
            double volatilityReb = reb.getCapletVolatility(maturity, a, b, c, d);
            Console.WriteLine("instantanious volatility with Rebonato equation : " + volatilityReb.ToString());

            logger.Info("calculate the price of spread option.");
            Normal normal = new ModelLibrary.diffusion.Normal();
            SpreadOption spreadOption = new SpreadOption(strike, maturity, true);
            double spreadOptionPrice = normal.evaluate(spreadOption, interestRate, volatility, spot);
            Console.WriteLine("spread option price : " + spreadOptionPrice.ToString());

            logger.Info("=============================pricing finished=============================");
        }
    }
}
