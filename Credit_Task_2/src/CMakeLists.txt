
add_library(
    ${CREDIT_TASK_LIBRARY}
    STATIC
    Assessment.h Assessment.cc
    User.h User.cc Unit.h Unit.cc
    Lecturer.h Lecturer.cc
    Student.h Student.cc ClassRoom.h ClassRoom.cc
    QueryInterface.h QueryInterface.cc
)


target_include_directories(
    ${CREDIT_TASK_LIBRARY}
    PUBLIC
    "./"
)
