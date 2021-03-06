﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace ModelLibrary.MonteCarlo
{
    static class LognormalImpl
    {
        static public double calculateNextStep(double thisStep, double drift, double dt, double volatility, double randomness)
        {
            return thisStep + drift * dt + volatility * Math.Sqrt(dt) * randomness;

        }
        static public double calculateDrift(double interestRate, double volatility, double dividend)
        {
            return (interestRate - dividend - 0.5 * volatility * volatility); // impl

        }

        static public double calculateDiscountFactor(PlainVanillaOption contract, double interestRate)
        {
            return Math.Exp(-interestRate * contract._maturity);
        }
    }
}
