cmake_minimum_required(
    VERSION 3.16
)

project(
    Credit_Task_2
    VERSION 1.0.0
    DESCRIPTION "Student Grading System"
    LANGUAGES CXX
)

set(CXX_STANDARD            17)
set(CXX_STANDARD_REQUIRED   ON)


set(CREDIT_TASK_LIBRARY     Credit_Task_Lib)
set(CREDIT_TASK_TEST              UnitTests)
set(TEST_EXECUTABLE               Test_Exec)
set(CREDIT_TASK_EXECUTABLE       Executable)

option(RUN_TESTS "Turn this option on if you'd like to run the unit tests")

set(RUN_TESTS               OFF)

if(RUN_TESTS)
    include(GoogleTest)
    include(FetchContent)
    include(CTest)

    FetchContent_Declare(
        Google_Test
        GIT_REPOSITORY  https://github.com/google/googletest.git
        GIT_TAG         703bd9caab50b139428cea1aaff9974ebee5742e
    )
    FetchContent_MakeAvailable(Google_Test)

    add_library(GTest::GTest INTERFACE IMPORTED)
    target_link_libraries(
        GTest::GTest
        INTERFACE
        gtest_main
    )

endif()

add_subdirectory(src)
add_subdirectory(application)
add_subdirectory(tests)
