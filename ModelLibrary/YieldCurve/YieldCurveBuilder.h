#pragma once
#include "YieldCurve.h"

#ifdef CPP_EXPORTS
#define CPP_API __declspec(dllexport)
#else
#define CPP_API __declspec(dllimport)
#endif

namespace yc {
    class YieldCurveBuilder {
    private:

    public:
        CPP_API YieldCurveBuilder();
        CPP_API yc::YieldCurve createYieldCurve();
    };
}
