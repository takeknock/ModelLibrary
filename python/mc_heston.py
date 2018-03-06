from numpy import sqrt, exp
import numpy as np

def mc_heston( \
    is_call, \
    spot, \
    strike, \
    maturity, \
    initial_volatility, \
    long_term_mean_volatility, \
    rate_reversion, \
    volvol, \
    correlation, \
    riskfree_rate, \
    number_of_paths, \
    number_of_steps):

    pv = 0.0

    dt = maturity / float(number_of_steps)
    payoff = 0
    for path_index in range(number_of_paths):
        volatility_at_t = initial_volatility
        underlying_at_t = spot
        for step_index in range(number_of_steps):
            randomness_of_underlying = np.random.normal(0, 1)
            randomness_of_volatility = \
                correlation * sqrt(1 - correlation**2) \
                * np.random.normal(0, 1)
            # in the following row, randomness_of_underlying is mistake?
            volatility_at_t = (sqrt(volatility_at_t) + 0.5 * volvol \
                    * sqrt(dt) * randomness_of_underlying) ** 2 \
                - rate_reversion * (volatility_at_t - long_term_mean_volatility) * dt \
                - 0.25 * volvol ** 2 * dt

            underlying_at_t *= exp((riskfree_rate - 0.5 * volatility_at_t) * dt \
                + sqrt(volatility_at_t * dt) * randomness_of_volatility)

    if is_call:
        payoff += max(underlying_at_t - strike, 0)
    else:
        payoff += max(strike - underlying_at_t, 0)

    # Assumption: risk free rate is constant for time.
    discount_factor_at_payment = exp(-riskfree_rate * maturity)

    return (payoff/float(number_of_paths)) * discount_factor_at_payment



def main():
    is_call = False
    spot = 100.0
    strike = 100.0
    maturity = 10.0
    initial_variance = 0.2
    long_term_mean_variance = 0.1
    rate_reversion = 0.1
    volvol = 0.15
    correlation = 0.34
    riskfree_rate = 0.02
    number_of_paths = 10000
    number_of_steps = 100

    pv = mc_heston(is_call, spot, strike, maturity, initial_variance, \
        long_term_mean_variance, rate_reversion, volvol, correlation, riskfree_rate, \
        number_of_paths, number_of_steps)
    print(pv)


if __name__ == "__main__":
    main()
