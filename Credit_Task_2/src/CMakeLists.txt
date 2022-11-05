add_library(
    ${CREDIT_TASK_LIBRARY}
    STATIC Assessment.cc Unit.cc Student.cc ClassRoom.cc Lecturer.cc User.cc
)


target_include_directories(
    ${CREDIT_TASK_LIBRARY}
    PUBLIC
    "./"
)
