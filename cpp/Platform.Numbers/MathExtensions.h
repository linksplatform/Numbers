namespace Platform::Numbers
{
    class MathExtensions
    {
        public: template <typename T> static T Abs(T* x) where T : struct => *x = Math<T>.Abs(*x);

        public: template <typename T> static T Negate(T* x) where T : struct => *x = Math<T>.Negate(*x);
    };
}
