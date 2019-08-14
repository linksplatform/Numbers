namespace Platform.Numbers
{
    public static class BitwiseExtensions
    {
        public static T PartialWrite<T>(this ref T target, T source, int shift, int limit) where T : struct => target = Bit<T>.PartialWrite(target, source, shift, limit);
        public static T PartialRead<T>(this T target, int shift, int limit) => Bit<T>.PartialRead(target, shift, limit);
    }
}
