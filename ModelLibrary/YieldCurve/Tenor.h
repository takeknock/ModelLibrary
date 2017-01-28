#pragma once
#include <string>

#ifdef CPP_EXPORTS
#define CPP_API __declspec(dllexport)
#else
#define CPP_API __declspec(dllimport)
#endif


namespace yc {

    class Tenor {
    private:
        std::string _tenor;
    public:
        CPP_API Tenor(std::string tenor);


    };

}//namespace yc {
