#pragma once

#include <cppunit\extensions\HelperMacros.h>
#include <gmock\gmock.h>
#include "../YieldCurve/YieldCurve.h"
#include "../YieldCurve/sample.h"

namespace yct {

    class YieldCurveTest {
    private:

    public:
        void buildTest();
        void sampleTest();
    };

} // namespace yct
