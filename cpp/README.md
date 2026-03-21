[![Unlicense](https://img.shields.io/badge/license-Unlicense-blue.svg)](http://unlicense.org/)
[![Actions Status](https://github.com/linksplatform/Numbers/workflows/Deploy%20new%20cpp%20version/badge.svg)](https://github.com/linksplatform/Numbers/actions?workflow=Deploy+new+cpp+version)

# [Numbers](https://github.com/linksplatform/Numbers) for C++

LinksPlatform's Platform.Numbers Template Library.

Conan package: [platform.numbers](https://conan.io/center/platform.numbers)

## Overview

This library provides header-only numeric utility templates used
throughout the LinksPlatform ecosystem:

- **`Bit`** — Bit manipulation utilities for integral types.

## Installation

Using [Conan](https://conan.io/):

```ini
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

- [Platform.Interfaces](https://github.com/linksplatform/Interfaces)
  (C++ version)

## License

This library is released to the **public domain** under the [Unlicense](http://unlicense.org/).

The Unlicense is the most permissive license available — it places no restrictions whatsoever on users. You are free to copy, modify, publish, use, compile, sell, or distribute this software for any purpose, commercial or non-commercial, in any way you choose, with no conditions attached.

Unlike LGPL, which forces users to redistribute modifications under the same license and comply with specific obligations (linking restrictions, source disclosure for modifications), the Unlicense imposes **no obligations at all**. It is truly free as in freedom.
