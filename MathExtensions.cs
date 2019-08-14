namespace Platform.Numbers
{
    public static class MathExtensions
    {
        public static T Abs<T>(this ref T x) where T : struct => x = Math<T>.Abs(x);
        public static T Negate<T>(this ref T x) where T : struct => x = Math<T>.Negate(x);
    }
}
