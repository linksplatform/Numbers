using System;
using System.Runtime.CompilerServices;

namespace Platform.Numbers
{
    public class CalcResult<T>
    {
        public CalcResult() : this(default) { }

        public CalcResult(T value)
        {
            Value = value;
            IsValid = true;
        }

        #region Arithmetic operations
      
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Add(T a)
        {
            if (IsValid)
            {
                try
                {
                    _value = Arithmetic<T>.Add(_value, a);
                }
                catch (Exception e)
                {
                    Message = e.Message;
                    IsValid = false;
                }
            }
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Subtract(T a)
        {
            if (IsValid)
            {
                try
                {
                    _value = Arithmetic<T>.Subtract(_value, a);
                }
                catch (Exception e)
                {
                    Message = e.Message;
                    IsValid = false;
                }
            }
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Multiply(T a)
        {
            if (IsValid)
            {
                try
                {
                    _value = Arithmetic<T>.Multiply(_value, a);
                }
                catch (Exception e)
                {
                    Message = e.Message;
                    IsValid = false;
                }
            }
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Divide(T a)
        {
            if (IsValid)
            {
                try
                {
                    _value = Arithmetic<T>.Divide(_value, a);
                }
                catch (Exception e)
                {
                    Message = e.Message;
                    IsValid = false;
                }
            }
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Add(CalcResult<T> cr)
        {
            if (IsValid)
            {
                if (cr.IsValid)
                {
                    try
                    {
                        _value = Arithmetic<T>.Add(_value, cr._value);
                    }
                    catch (Exception e)
                    {
                        Message = e.Message;
                        IsValid = false;
                    }
                }
                else
                {
                    return cr;
                }
            }
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Subtract(CalcResult<T> cr)
        {
            if (IsValid)
            {
                if (cr.IsValid)
                {
                    try
                    {
                        _value = Arithmetic<T>.Subtract(_value, cr._value);
                    }
                    catch (Exception e)
                    {
                        Message = e.Message;
                        IsValid = false;
                    }
                }
                else
                {
                    return cr;
                }
            }
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Multiply(CalcResult<T> cr)
        {
            if (IsValid)
            {
                if (cr.IsValid)
                {
                    try
                    {
                        _value = Arithmetic<T>.Multiply(_value, cr._value);
                    }
                    catch (Exception e)
                    {
                        Message = e.Message;
                        IsValid = false;
                    }
                }
                else
                {
                    return cr;
                }
            }
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Divide(CalcResult<T> cr)
        {
            if (IsValid)
            {
                if (cr.IsValid)
                {
                    try
                    {
                        _value = Arithmetic<T>.Divide(_value, cr._value);
                    }
                    catch (Exception e)
                    {
                        Message = e.Message;
                        IsValid = false;
                    }
                }
                else
                {
                    return cr;
                }
            }
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Increment()
        {
            if (IsValid)
            {
                try
                {
                    _value = Arithmetic<T>.Increment(_value);
                }
                catch (Exception e)
                {
                    Message = e.Message;
                    IsValid = false;
                }
            }
            return this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public CalcResult<T> Decrement()
        {
            if (IsValid)
            {
                try
                {
                    _value = Arithmetic<T>.Decrement(_value);
                }
                catch (Exception e)
                {
                    Message = e.Message;
                    IsValid = false;
                }
            }
            return this;
        }
        #endregion

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                IsValid = true;
            }
        }

        public bool IsValid { get; set; }

        public string Message { get; private set; }

        private T _value;

        #region Operator overloading

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator ++(CalcResult<T> cr)
        {
            if (cr.IsValid)
            {
                try
                {
                    cr._value = Arithmetic<T>.Increment(cr._value);
                }
                catch (Exception e)
                {
                    cr.Message = e.Message;
                    cr.IsValid = false;
                }
            }
            return cr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator --(CalcResult<T> cr)
        {
            if (cr.IsValid)
            {
                try
                {
                    cr._value = Arithmetic<T>.Decrement(cr._value);
                }
                catch (Exception e)
                {
                    cr.Message = e.Message;
                    cr.IsValid = false;
                }
            }
            return cr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator +(CalcResult<T> cr, T v)
        {
            if (cr.IsValid)
            {
                try
                {
                    cr._value = Arithmetic<T>.Add(cr._value, v);
                }
                catch (Exception e)
                {
                    cr.Message = e.Message;
                    cr.IsValid = false;
                }
            }
            return cr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator -(CalcResult<T> cr, T v)
        {
            if (cr.IsValid)
            {
                try
                {
                    cr._value = Arithmetic<T>.Subtract(cr._value, v);
                }
                catch (Exception e)
                {
                    cr.Message = e.Message;
                    cr.IsValid = false;
                }
            }
            return cr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator *(CalcResult<T> cr, T v)
        {
            if (cr.IsValid)
            {
                try
                {
                    cr._value = Arithmetic<T>.Multiply(cr._value, v);
                }
                catch (Exception e)
                {
                    cr.Message = e.Message;
                    cr.IsValid = false;
                }
            }
            return cr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator /(CalcResult<T> cr, T v)
        {
            if (cr.IsValid)
            {
                try
                {
                    cr._value = Arithmetic<T>.Divide(cr._value, v);
                }
                catch (Exception e)
                {
                    cr.Message = e.Message;
                    cr.IsValid = false;
                }
            }
            return cr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator +(CalcResult<T> a, CalcResult<T> b)
        {
            if (a.IsValid)
            {
                if (b.IsValid)
                {
                    try
                    {
                        a._value = Arithmetic<T>.Add(a._value, b._value);
                    }
                    catch (Exception e)
                    {
                        a.Message = e.Message;
                        a.IsValid = false;
                    }
                }
                else
                {
                    return b;
                }
            }
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator -(CalcResult<T> a, CalcResult<T> b)
        {
            if (a.IsValid)
            {
                if (b.IsValid)
                {
                    try
                    {
                        a._value = Arithmetic<T>.Subtract(a._value, b._value);
                    }
                    catch (Exception e)
                    {
                        a.Message = e.Message;
                        a.IsValid = false;
                    }
                }
                else
                {
                    return b;
                }
            }
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator *(CalcResult<T> a, CalcResult<T> b)
        {
            if (a.IsValid)
            {
                if (b.IsValid)
                {
                    try
                    {
                        a._value = Arithmetic<T>.Multiply(a._value, b._value);
                    }
                    catch (Exception e)
                    {
                        a.Message = e.Message;
                        b.IsValid = false;
                    }
                }
                else
                {
                    return b;
                }
            }
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CalcResult<T> operator /(CalcResult<T> a, CalcResult<T> b)
        {
            if (a.IsValid)
            {
                if (b.IsValid)
                {
                    try
                    {
                        a._value = Arithmetic<T>.Divide(a._value, b._value);
                    }
                    catch (Exception e)
                    {
                        a.Message = e.Message;
                        a.IsValid = false;
                    }
                }
                else
                {
                    return b;
                }
            }
            return a;
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(CalcResult<T> v) => v.IsValid;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator CalcResult<T>(T v) => new CalcResult<T>(v);
    }
}
