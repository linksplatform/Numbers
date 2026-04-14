---
bump: minor
---

### Added
- Factorial implementation in Rust (`math` module) with precomputed lookup table
- Rust benchmarks (Criterion) comparing branch prediction optimization strategies: baseline, cold-path separation, unlikely-first, force-inline, and direct array access
- C++ benchmarks (Google Benchmark) comparing `[[likely]]`/`[[unlikely]]`, `__builtin_expect`, force-inline, separate throw, and direct array access
- C# benchmarks (BenchmarkDotNet) comparing `AggressiveInlining`, `AggressiveOptimization`, `DoesNotReturn`, and generic implementations
