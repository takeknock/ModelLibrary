# -*- coding: utf-8 -*-
"""
Created on Sun Jun 12 17:39:49 2016

@author: mmatthew_43
"""

def black_scholes_merton_call_value(spot, 
                                   strike, 
                                   maturity, 
                                   interestRate, 
                                   volatility):
    from math import log, sqrt, exp
    from scipy import stats
    
    spot = float(spot)
    d1 = ((log(spot / strike) + 
            (interestRate + 0.5 * volatility * volatility) * maturity) 
        / (volatility * sqrt(maturity)))
    d2 = d1 - volatility * sqrt(maturity)
    
    value = (spot * stats.norm.cdf(d1, 0.0, 1.0)
        - strike * exp(-interestRate * maturity) * stats.norm.cdf(d2,0.0,1.0))
    
    return value                                   


def black_scholes_merton_vega(spot, strike, maturity, interestRate, volatility):
    from math import log, sqrt
    from scipy import stats
    
    spot = float(spot)
    d1 = ((log(spot / strike) 
            + (interestRate + 0.5 * volatility * volatility) * maturity) 
        / (volatility * sqrt(maturity)))
        
    vega = spot * stats.norm.cdf(d1, 0.0, 1.0) * sqrt(maturity)
    
    return vega
    
    
def black_scholes_merton_call_implied_volatility(spot, 
                                                 strike, 
                                                 maturity, 
                                                 interestRate, 
                                                 call_value, 
                                                 implied_volatility, 
                                                 number_of_iteration = 100):
    
    for i in range(number_of_iteration):
        implied_volatility -= (((black_scholes_merton_call_value(
                    spot, strike, maturity, interestRate, implied_volatility)
                - call_value))
            / black_scholes_merton_vega(
                spot, strike, maturity, interestRate, volatility))
            
    return implied_volatility
                                                 

if __name__ == "__main__":
    strike = 100
    spot = 100
    maturity = 1.0
    interestRate = 0.01
    volatility = 0.2
    
    price = black_scholes_merton_call_value(
        spot, strike, maturity, interestRate, volatility)

    print(price)

    implied_volatility = black_scholes_merton_call_implied_volatility(
        spot, strike, maturity, interestRate, price, 0.5, 10)

    print(implied_volatility)
    
    
