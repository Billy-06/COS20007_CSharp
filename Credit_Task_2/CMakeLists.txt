cmake_minimum_required(
    VERSION 3.16
)

project(
    Credit_Task_2
    VERSION 1.0.0
    LANGUAGES CXX
)



set(CREDIT_TASK_LIBRARY Credit_Task_Lib)
set(CREDIT_TASK_EXECUTABLE Executable)

add_subdirectory(src)
add_subdirectory(application)
