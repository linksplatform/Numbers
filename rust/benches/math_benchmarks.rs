use criterion::{Criterion, black_box, criterion_group, criterion_main};
use platform_num::math;

fn bench_factorial_baseline(c: &mut Criterion) {
    c.bench_function("factorial_baseline", |b| {
        b.iter(|| math::factorial(black_box(19)))
    });
}

fn bench_factorial_with_likely(c: &mut Criterion) {
    c.bench_function("factorial_with_likely", |b| {
        b.iter(|| math::factorial_with_likely(black_box(19)))
    });
}

fn bench_factorial_with_unlikely_first(c: &mut Criterion) {
    c.bench_function("factorial_with_unlikely_first", |b| {
        b.iter(|| math::factorial_with_unlikely_first(black_box(19)))
    });
}

fn bench_factorial_direct_array_access(c: &mut Criterion) {
    c.bench_function("factorial_direct_array_access", |b| {
        b.iter(|| math::factorial_direct_array_access(black_box(19)))
    });
}

fn bench_factorial_with_likely_and_force_inline(c: &mut Criterion) {
    c.bench_function("factorial_with_likely_and_force_inline", |b| {
        b.iter(|| math::factorial_with_likely_and_force_inline(black_box(19)))
    });
}

criterion_group!(
    benches,
    bench_factorial_baseline,
    bench_factorial_with_likely,
    bench_factorial_with_unlikely_first,
    bench_factorial_direct_array_access,
    bench_factorial_with_likely_and_force_inline,
);
criterion_main!(benches);
