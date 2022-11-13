add_executable(
    ${CREDIT_TASK_EXECUTABLE}
    Main.cc
)

# Linkt the executable to the header files
target_link_libraries(
    ${CREDIT_TASK_EXECUTABLE}
    PUBLIC
    ${CREDIT_TASK_LIBRARY}
)
