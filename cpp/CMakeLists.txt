cmake_minimum_required(VERSION 3.8)

project(Platform.Numbers)
include(${CMAKE_BINARY_DIR}/conanbuildinfo.cmake)
conan_basic_setup(TARGETS)

add_library(${PROJECT_NAME}.Library INTERFACE)
target_include_directories(${PROJECT_NAME}.Library INTERFACE ${PROJECT_NAME})

if((DEFINED LINKS_PLATFORM_TESTS) AND (${LINKS_PLATFORM_TESTS}))
    add_executable(${PROJECT_NAME}.Tests ${PROJECT_NAME}.Tests/AllTests.cpp)
    set_target_properties(${PROJECT_NAME}.Tests PROPERTIES CXX_STANDARD 20)
    target_link_libraries(${PROJECT_NAME}.Tests PUBLIC CONAN_PKG::gtest)
    target_link_libraries(${PROJECT_NAME}.Tests PUBLIC ${PROJECT_NAME}.Library)
endif()