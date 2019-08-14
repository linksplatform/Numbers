#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    public static class ArithmeticExtensions
    {
        public static T Decrement<T>(this ref T x) where T : struct => x = Arithmetic<T>.Decrement(x);
        public static T Increment<T>(this ref T x) where T : struct => x = Arithmetic<T>.Increment(x);
    }
}
