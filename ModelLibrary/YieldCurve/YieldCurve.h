#pragma once

#ifdef CPP_EXPORTS
#define CPP_API __declspec(dllexport)
#else
#define CPP_API __declspec(dllimport)
#endif

namespace yc {
    class YieldCurve {
    private:

    public:
        CPP_API YieldCurve();
        CPP_API void build();
    };

}// namespace yc