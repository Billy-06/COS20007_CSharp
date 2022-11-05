add_executable(Executable Main.cc)

target_include_directories(
    Executable PUBLIC ${CREDIT_TASK_LIBRARY}
)
