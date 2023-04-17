if(RUN_TESTS)
    add_executable(
        ${TEST_EXECUTABLE}
        StudentTests.cc
    )

    target_link_libraries(
        ${TEST_EXECUTABLE}
        PRIVATE
        GTest::GTest
    )
    target_link_libraries(
        ${TEST_EXECUTABLE}
        PUBLIC
        ${CREDIT_TASK_LIBRARY}
    )

    add_test(
        NAME ${CREDIT_TASK_TEST}
        COMMAND ${TEST_EXECUTABLE}
    )
endif()
