cmake_minimum_required(VERSION 3.23)
project(RoverProject)

include(CTest)

set(CMAKE_CXX_STANDARD 17)

add_executable(RoverProject main.cpp
        Object.h Object.cpp
        Rover.h Rover.cpp
        Battery.h Battery.cpp
        Radar.h Radar.cpp
        Drill.h Drill.cpp
        Device.h Device.cpp
        SolarPanel.h SolarPanel.cpp)

add_test(NAME TestRover COMMAND CPPUnitTests/TestRover.cpp)
