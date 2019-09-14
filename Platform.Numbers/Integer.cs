using System;
using System.Runtime.CompilerServices;
using Platform.Converters;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    public struct Integer : IEquatable<Integer>
    {
        public readonly ulong Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Integer(ulong value) => Value = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(ulong integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(long integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(uint integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(int integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(ushort integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(short integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(byte integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(sbyte integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(bool integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong(Integer integer) => integer.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long(Integer integer) => To.Int64(integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint(Integer integer) => To.UInt32(integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(Integer integer) => To.Int32(integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort(Integer integer) => To.UInt16(integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short(Integer integer) => To.Int16(integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte(Integer integer) => To.Byte(integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte(Integer integer) => To.SByte(integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(Integer integer) => To.Boolean(integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Integer other) => Value == other.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => Value.ToString();
    }
}
