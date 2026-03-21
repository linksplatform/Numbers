[![Actions Status](https://github.com/linksplatform/Numbers/workflows/Deploy%20new%20cpp%20version/badge.svg)](https://github.com/linksplatform/Numbers/actions?workflow=Deploy+new+cpp+version)

# [Numbers](https://github.com/linksplatform/Numbers) for C++

LinksPlatform's Platform.Numbers Template Library.

Conan package: [platform.numbers](https://conan.io/center/platform.numbers)

## Overview

This library provides header-only numeric utility templates used throughout the LinksPlatform ecosystem:

- **`Bit`** — Bit manipulation utilities for integral types.

## Installation

Using [Conan](https://conan.io/):

```
[requires]
platform.numbers/[latest]
```

Or using CMake directly:

```cmake
add_subdirectory(cpp)
target_link_libraries(your_target PRIVATE Platform.Numbers)
```

## Usage

```cpp
#include <Platform.Numbers.h>

// Use bit operations from Platform.Numbers
```

## Depend on
*   [Platform.Interfaces](https://github.com/linksplatform/Interfaces) (C++ version)
