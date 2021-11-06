

// ReSharper disable StaticFieldInGenericType

namespace Platform::Numbers
{
    template <typename ...> class Bit;
    template <typename T> class Bit<T>
    {
        public: static readonly Func<T, T> Not = CompileNotDelegate();

        public: static readonly Func<T, T, T> Or = CompileOrDelegate();

        public: static readonly Func<T, T, T> And = CompileAndDelegate();

        public: static readonly Func<T, std::int32_t, T> ShiftLeft = CompileShiftLeftDelegate();

        public: static readonly Func<T, std::int32_t, T> ShiftRight = CompileShiftRightDelegate();

        public: static readonly Func<T, T, std::int32_t, std::int32_t, T> PartialWrite = CompilePartialWriteDelegate();

        public: static readonly Func<T, std::int32_t, std::int32_t, T> PartialRead = CompilePartialReadDelegate();

        private: static Func<T, T> CompileNotDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0);
                emiter.Not();
                emiter.Return();
            });
        }

        private: static Func<T, T, T> CompileOrDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.Or();
                emiter.Return();
            });
        }

        private: static Func<T, T, T> CompileAndDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.And();
                emiter.Return();
            });
        }

        private: static Func<T, std::int32_t, T> CompileShiftLeftDelegate()
        {
            return DelegateHelpers.Compile<Func<T, std::int32_t, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.ShiftLeft();
                emiter.Return();
            });
        }

        private: static Func<T, std::int32_t, T> CompileShiftRightDelegate()
        {
            return DelegateHelpers.Compile<Func<T, std::int32_t, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                emiter.LoadArguments(0, 1);
                emiter.ShiftRight<T>();
                emiter.Return();
            });
        }

        private: static Func<T, T, std::int32_t, std::int32_t, T> CompilePartialWriteDelegate()
        {
            return DelegateHelpers.Compile<Func<T, T, std::int32_t, std::int32_t, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                auto constants = GetConstants();
                auto bitsNumber = constants.Item1;
                auto numberFilledWithOnes = constants.Item2;
                std::uint16_t shiftArgument = 2;
                std::uint16_t limitArgument = 3;
                auto checkLimit = emiter.DefineLabel();
                auto calculateSourceMask = emiter.DefineLabel();
                emiter.LoadArgument(shiftArgument);
                emiter.LoadConstant(0);
                emiter.BranchIfGreaterOrEqual(checkLimit);
                emiter.LoadConstant(bitsNumber);
                emiter.LoadArgument(shiftArgument);
                emiter.Add();
                emiter.StoreArgument(shiftArgument);
                emiter.MarkLabel(checkLimit);
                emiter.LoadArgument(limitArgument);
                emiter.LoadConstant(0);
                emiter.BranchIfGreaterOrEqual(calculateSourceMask);
                emiter.LoadConstant(bitsNumber);
                emiter.LoadArgument(limitArgument);
                emiter.Add();
                emiter.StoreArgument(limitArgument);
                emiter.MarkLabel(calculateSourceMask);
                auto sourceMask = emiter.DeclareLocal<T>();
                auto targetMask = emiter.DeclareLocal<T>();
                emiter.LoadConstant(typeof(T), numberFilledWithOnes);
                emiter.LoadArgument(limitArgument);
                emiter.ShiftLeft();
                emiter.Not();
                emiter.LoadConstant(typeof(T), numberFilledWithOnes);
                emiter.And();
                emiter.StoreLocal(sourceMask);
                emiter.LoadLocal(sourceMask);
                emiter.LoadArgument(shiftArgument);
                emiter.ShiftLeft();
                emiter.Not();
                emiter.StoreLocal(targetMask);
                emiter.LoadArgument(0);
                emiter.LoadLocal(targetMask);
                emiter.And();
                emiter.LoadArgument(1);
                emiter.LoadLocal(sourceMask);
                emiter.And();
                emiter.LoadArgument(shiftArgument);
                emiter.ShiftLeft();
                emiter.Or();
                emiter.Return();
            });
        }

        private: static Func<T, std::int32_t, std::int32_t, T> CompilePartialReadDelegate()
        {
            return DelegateHelpers.Compile<Func<T, std::int32_t, std::int32_t, T>>(emiter =>
            {
                Ensure.Always.IsNumeric<T>();
                auto constants = GetConstants();
                auto bitsNumber = constants.Item1;
                auto numberFilledWithOnes = constants.Item2;
                std::uint16_t shiftArgument = 1;
                std::uint16_t limitArgument = 2;
                auto checkLimit = emiter.DefineLabel();
                auto calculateSourceMask = emiter.DefineLabel();
                emiter.LoadArgument(shiftArgument);
                emiter.LoadConstant(0);
                emiter.BranchIfGreaterOrEqual(checkLimit);
                emiter.LoadConstant(bitsNumber);
                emiter.LoadArgument(shiftArgument);
                emiter.Add();
                emiter.StoreArgument(shiftArgument);
                emiter.MarkLabel(checkLimit);
                emiter.LoadArgument(limitArgument);
                emiter.LoadConstant(0);
                emiter.BranchIfGreaterOrEqual(calculateSourceMask);
                emiter.LoadConstant(bitsNumber);
                emiter.LoadArgument(limitArgument);
                emiter.Add();
                emiter.StoreArgument(limitArgument);
                emiter.MarkLabel(calculateSourceMask);
                auto sourceMask = emiter.DeclareLocal<T>();
                auto targetMask = emiter.DeclareLocal<T>();
                emiter.LoadConstant(typeof(T), numberFilledWithOnes);
                emiter.LoadArgument(limitArgument);
                emiter.ShiftLeft();
                emiter.Not();
                emiter.LoadConstant(typeof(T), numberFilledWithOnes);
                emiter.And();
                emiter.StoreLocal(sourceMask);
                emiter.LoadLocal(sourceMask);
                emiter.LoadArgument(shiftArgument);
                emiter.ShiftLeft();
                emiter.StoreLocal(targetMask);
                emiter.LoadArgument(0);
                emiter.LoadLocal(targetMask);
                emiter.And();
                emiter.LoadArgument(shiftArgument);
                emiter.ShiftRight<T>();
                emiter.Return();
            });
        }

        private: static Tuple<std::int32_t, T> GetConstants()
        {
            auto type = typeof(T);
            if (type == typeof(std::uint64_t))
            {
                return Tuple<std::int32_t, T>(64, (T)(void*)std::numeric_limits<std::uint64_t>::max());
            }
            if (type == typeof(std::uint32_t))
            {
                return Tuple<std::int32_t, T>(32, (T)(void*)std::numeric_limits<std::uint32_t>::max());
            }
            if (type == typeof(std::uint16_t))
            {
                return Tuple<std::int32_t, T>(16, (T)(void*)std::numeric_limits<std::uint16_t>::max());
            }
            if (type == typeof(std::uint8_t))
            {
                return Tuple<std::int32_t, T>(8, (T)(void*)std::numeric_limits<std::uint8_t>::max());
            }
            throw std::logic_error("Not supported exception.");
        }
    };
}
