using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Platform.Exceptions;
using Platform.Reflection;
using Platform.Converters;

// ReSharper disable StaticFieldInGenericType
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable RECS0108 // Warns about static fields in generic types

namespace Platform.Numbers
{
    public struct Integer<T> : IEquatable<Integer<T>>
    {
        private static readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;
        private static readonly Func<ulong, Integer<T>> _create;

        public static readonly T Zero;
        public static readonly T One;
        public static readonly T Two;

        public readonly T Value;

        static Integer()
        {
            _create = CompileCreateDelegate();
            try
            {
                Zero = default;
                One = Arithmetic.Increment(Zero);
                Two = Arithmetic.Increment(One);
            }
            catch (Exception exception)
            {
                exception.Ignore();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Integer(T value) => Value = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer(Integer<T> integer)
        {
            if (typeof(T) == typeof(Integer))
            {
                return (Integer)(object)integer.Value;
            }
            return Convert.ToUInt64(integer.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong(Integer<T> integer) => ((Integer)integer).Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator T(Integer<T> integer) => integer.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(T integer) => new Integer<T>(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(ulong integer) => _create(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(Integer integer) => _create(integer.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(long integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(uint integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(int integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(ushort integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(short integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(byte integer) => new Integer(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(sbyte integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Integer<T>(bool integer) => To.UInt64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long(Integer<T> integer) => To.Int64(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint(Integer<T> integer) => To.UInt32(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(Integer<T> integer) => To.Int32(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort(Integer<T> integer) => To.UInt16(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short(Integer<T> integer) => To.Int16(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte(Integer<T> integer) => To.Byte(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte(Integer<T> integer) => To.SByte(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(Integer<T> integer) => To.Boolean(integer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Integer<T> other) => _equalityComparer.Equals(Value, other.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => Value.ToString();

        private static Func<ulong, Integer<T>> CompileCreateDelegate()
        {
            return DelegateHelpers.Compile<Func<ulong, Integer<T>>>(emiter =>
            {
                if (typeof(T) != typeof(Integer))
                {
                    Ensure.Always.CanBeNumeric<T>();
                }
                emiter.LoadArgument(0);
                if (typeof(T) != typeof(ulong) && typeof(T) != typeof(Integer))
                {
                    emiter.Call(typeof(To).GetMethod(typeof(T).Name, Types<ulong>.Array));
                }
                if (NumericType<T>.IsNullable)
                {
                    emiter.NewObject(typeof(T), NumericType<T>.UnderlyingType);
                }
                if (typeof(T) == typeof(Integer))
                {
                    emiter.NewObject(typeof(Integer), typeof(ulong));
                }
                emiter.NewObject(typeof(Integer<T>), typeof(T));
                emiter.Return();
            });
        }
    }
}
