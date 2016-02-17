#include <iostream>
#include <cmath>

double calculateSabrVolatility(double forwardRate, double ATMVolatility, double beta, double gradientOfSmile, double curvature, double maturity, double strike)
{
    double z;
    double chi;

    z = (curvature / ATMVolatility) 
        * std::pow((forwardRate * strike), 
            (0.5 * (1 - beta)) * std::log(forwardRate / strike));

    std::cout << "z: " << z << std::endl;

    chi = std::log((std::sqrt(1 - 2 * gradientOfSmile * z + z * z) + z - gradientOfSmile) / (1 - gradientOfSmile));

    std::cout << "chi: " << chi << std::endl;

    double volatility;

    if (forwardRate == strike) {
        volatility = ATMVolatility / std::pow(forwardRate, (1 - beta));
        volatility = volatility * (1 + ((1 - beta) * (1 - beta) * ATMVolatility * ATMVolatility / (24 * std::pow(forwardRate, (2 - 2 * beta)) + 0.25 * gradientOfSmile * beta * curvature * ATMVolatility / std::pow(forwardRate, 1 - beta) + (2.0 - 3.0 * gradientOfSmile * gradientOfSmile) * curvature * curvature) * maturity));
    } else {
        volatility = ATMVolatility / std::pow(forwardRate * strike, 0.5 * (1 - beta));
        volatility = volatility / (1 * (1 - beta) * (1 - beta) / 24 * std::log(forwardRate / strike) * std::log(forwardRate / strike) * (1 - beta));

    }


    return volatility;
}


int main()
{
    const double forwardRate = 0.1;
    const double ATMVolatility = 0.1;
    const double beta = 0.2;
    const double gradientOfSmile = 0.02;
    const double curvature = 0.15;
    const double maturity = 0.4;
    const double strike = 1.0;

    const double price = calculateSabrVolatility(forwardRate, ATMVolatility, beta, gradientOfSmile, curvature, maturity, strike);
    std::cout << price << std::endl;
    return 0;
}
