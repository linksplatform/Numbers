namespace Platform::Numbers
{
    class ArithmeticExtensions
    {
        public: template <typename T> static T Increment(T* x) where T : struct => *x = Arithmetic<T>.Increment(*x);

        public: template <typename T> static T Decrement(T* x) where T : struct => *x = Arithmetic<T>.Decrement(*x);
    };
}
