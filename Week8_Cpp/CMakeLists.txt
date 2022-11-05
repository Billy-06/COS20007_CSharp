cmake_minimum_required(VERSION 3.23)
project(Week8_Cpp)

set(CMAKE_CXX_STANDARD 17)

add_executable(
        Week8_Cpp main.cpp
        Product.h Product.cpp
        Electrical.h Electrical.cpp
        Sports.h Sports.cpp
        Order.h Order.cpp
        )
