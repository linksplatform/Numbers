using System;
using System.Runtime.CompilerServices;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Numbers
{
    [Obsolete]
    public struct Integer : IEquatable<Integer>
    {
        public readonly ulong Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Integer(ulong value) => Value = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(ulong integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(long integer) => unchecked((ulong)integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(uint integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(int integer) => unchecked((ulong)integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(ushort integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(short integer) => unchecked((ulong)integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(byte integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(sbyte integer) => unchecked((ulong)integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(bool integer) => integer ? 1UL : 0UL;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong(Integer integer) => integer.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long(Integer integer) => unchecked((long)integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint(Integer integer) => unchecked((uint)integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(Integer integer) => unchecked((int)integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort(Integer integer) => unchecked((ushort)integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short(Integer integer) => unchecked((short)integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte(Integer integer) => unchecked((byte)integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte(Integer integer) => unchecked((sbyte)integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(Integer integer) => integer.Value != 0UL;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Integer other) => Value == other.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => Value.ToString();
    }
}
