namespace Platform.Numbers
{
    public static class Bit
    {
        public static long Count(long x)
        {
            long n = 0;
            while (x != 0)
            {
                n++;
                x &= x - 1;
            }
            return n;
        }

        public static int GetLowestPosition(ulong value)
        {
            if (value == 0)
            {
                return -1;
            }
            var position = 0;
            while ((value & 1UL) == 0)
            {
                value >>= 1;
                ++position;
            }
            return position;
        }

        public static T PartialWrite<T>(T target, T source, int shift, int limit) => Bit<T>.PartialWrite(target, source, shift, limit);

        public static T PartialRead<T>(T target, int shift, int limit) => Bit<T>.PartialRead(target, shift, limit);
    }
}
