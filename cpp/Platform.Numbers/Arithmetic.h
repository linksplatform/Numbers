namespace Platform::Numbers
{
    class Arithmetic
    {
        public: template <typename T> static T Add(T x, T y) { return Arithmetic<T>.Add(x, y); }

        public: template <typename T> static T Subtract(T x, T y) { return Arithmetic<T>.Subtract(x, y); }

        public: template <typename T> static T Multiply(T x, T y) { return Arithmetic<T>.Multiply(x, y); }

        public: template <typename T> static T Divide(T x, T y) { return Arithmetic<T>.Divide(x, y); }

        public: template <typename T> static T Increment(T x) { return Arithmetic<T>.Increment(x); }

        public: template <typename T> static T Increment(T* x) { return x = Arithmetic<T>.Increment(x); }

        public: template <typename T> static T Decrement(T x) { return Arithmetic<T>.Decrement(x); }

        public: template <typename T> static T Decrement(T* x) { return x = Arithmetic<T>.Decrement(x); }
    };
}
