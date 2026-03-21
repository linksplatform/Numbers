[![NuGet Version and Downloads count](https://img.shields.io/nuget/v/Platform.Numbers?label=nuget&style=flat)](https://www.nuget.org/packages/Platform.Numbers)
[![Actions Status](https://github.com/linksplatform/Numbers/workflows/CD/badge.svg)](https://github.com/linksplatform/Numbers/actions?workflow=CD)

# [Numbers](https://github.com/linksplatform/Numbers) for C\#

LinksPlatform's Platform.Numbers Class Library.

Namespace: [Platform.Numbers](https://linksplatform.github.io/Numbers/csharp/api/Platform.Numbers.html)

NuGet package: [Platform.Numbers](https://www.nuget.org/packages/Platform.Numbers)

## Overview

This library provides helper classes for numeric operations used
throughout the LinksPlatform ecosystem:

- **`Arithmetic`** / **`Arithmetic<T>`** — Generic arithmetic
  operations for unconstrained types.
- **`Bit`** / **`Bit<T>`** — Bit manipulation utilities for
  generic types.
- **`Math`** / **`Math<T>`** — Mathematical operations
  (e.g. `Abs`, `Negate`) for generic types.
- Extension methods: `ArithmeticExtensions`, `BitExtensions`,
  `MathExtensions`.

## Installation

```shell
dotnet add package Platform.Numbers
```

## Usage

```csharp
using Platform.Numbers;

// Check if a bit is set
bool isSet = Bit.Get(0b1010, 3); // true

// Partial read from a number
long value = Bit.PartialRead(0xFF00, 8, 8); // 0xFF
```

## [Documentation](https://linksplatform.github.io/Numbers)

[PDF file](https://linksplatform.github.io/Numbers/csharp/Platform.Numbers.pdf)
with code for e-readers.

## Depend on

- [Platform.Converters](https://github.com/linksplatform/Converters)

## Dependent libraries

- [Platform.Unsafe](https://github.com/linksplatform/Unsafe)
- [Platform.Data](https://github.com/linksplatform/Data)
