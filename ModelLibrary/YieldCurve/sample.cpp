//#include <iostream>
#include <iostream>
#include <boost/numeric/ublas/io.hpp>
#include "sample.h"

namespace smp {
    void mutiply() {
        namespace ublas = boost::numeric::ublas;
        ublas::matrix<double> l(3, 4);
        ublas::matrix<double> r(2, 3);
        ublas::matrix<double> res = prod(l,r);
        std::cout << prod(l, r) << std::endl;

    }
}//namespace smp 