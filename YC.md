# YieldCurve construction
## flow
### from single IRS
$C_N\Sigma_{n=1}^N\Delta_nP_{t,T_n}$
$ = \Sigma_{n=1}^N\delta_nE_t[L(T_{n-1}, T_n)]P_{t,T_n}$
$ = \Sigma_{n=1}^N\delta_nL(T_{n-1}, T_n)P_{t,T_n}$
$ = \Sigma_{n=1}^N\delta_n\frac{1}{\delta_n}(\frac{P_{t, T_{n-1}}}{P_{t,T_n}}-1)P_{t,T_n}$
$ = P_{t, T_0} - P_{t, T_N}$

#### Assumptions
- Third equal assumes that day count convention of IRS is the same as the one of LIBOR.
- Third and Fourth equal assumes that cash flow calculation terms of interest rate in IRS is the same as LIBOR's cash flow calculation terms.(spot lag , fixing lag and etc. are the same.)
