from scipy.stats import norm
import math

def black_impl(forward, strike, maturity, volatility):
    option_value = 0
    if maturity * volatility == 0.0:
        option_value = max(forward - strike, 0.0)
        return option_value

    d1 = d_plus_black(forward, strike, maturity, volatility)
    d2 = d_minus_black(forward, strike, maturity, volatility)
    option_value = forward * norm.cdf(d1) - strike * norm.cdf(d2)
    return option_value

def d_plus_black(forward, strike, maturity, volatility):
    d_plus = (math.log(forward / strike) + 0.5 * volatility * volatility * maturity) \
        / (volatility * math.sqrt(maturity))
    return d_plus

def d_minus_black(forward, strike, maturity, volatility):
    d_minus = d_plus_black(forward, strike, maturity, volatility) \
        - volatility * math.sqrt(maturity)
    return d_minus

def black(forward, strike, maturity, volatility, is_call):
    option_value = black_impl(forward, strike, maturity, volatility) \
        if is_call else - black_impl(forward, strike, maturity, volatility)

    return option_value

def main():
    forward = 100
    strike = 70
    maturity = 10 # 10 years
    volatility = 0.2 # 20%
    is_call = True
    interest_rate = 0.1 # interest_rate at payment date
    discount_factor = 0.99
    option_value = black(forward, strike, maturity, volatility, is_call)
    present_value = discount_factor * option_value

    print("Option Value : ", present_value)

if __name__ == '__main__':
    main()
