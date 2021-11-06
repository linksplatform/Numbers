namespace Platform::Numbers
{
    class BitwiseExtensions
    {
        public: template <typename T> static T Not(T* target) where T : struct => *target = Bit.Not(*target);

        public: template <typename T> static T PartialWrite(T* target, T source, std::int32_t shift, std::int32_t limit) where T : struct => *target = Bit<T>.PartialWrite(*target, source, shift, limit);

        public: template <typename T> static T PartialRead(T target, std::int32_t shift, std::int32_t limit) { return Bit<T>.PartialRead(target, shift, limit); }
    };
}
