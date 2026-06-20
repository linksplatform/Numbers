using System;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using Platform.Reflection;

// ReSharper disable StaticFieldInGenericType

namespace Platform.Numbers
{
    /// <summary>
    /// <para>Represents a set of compiled math operations using object methods instead of delegates.</para>
    /// <para>Представляет набор скомпилированных математических операций, используя методы объекта вместо делегатов.</para>
    /// </summary>
    /// <remarks>
    /// <para>This implementation uses compiled object methods instead of delegates for better compiler optimization.</para>
    /// <para>Эта реализация использует скомпилированные методы объекта вместо делегатов для лучшей оптимизации компилятора.</para>
    /// </remarks>
    public static class MathHelpers<T>
        where T : INumberBase<T>
    {
        /// <summary>
        /// <para>Compiled math operations instance.</para>
        /// <para>Экземпляр скомпилированных математических операций.</para>
        /// </summary>
        public static readonly IMathOperations<T> Operations;

        static MathHelpers()
        {
            Operations = CompileOperationsClass();
        }

        private static IMathOperations<T> CompileOperationsClass()
        {
            // Create a dynamic assembly and module for this specific type T
            var assemblyName = new AssemblyName($"MathOperations_{typeof(T).Name}_{Guid.NewGuid():N}");
            var assembly = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var module = assembly.DefineDynamicModule("MathOperationsModule");
            
            // Create a concrete type that implements IMathOperations<T>
            var typeBuilder = module.DefineType(
                $"MathOperations_{typeof(T).Name}",
                TypeAttributes.Public | TypeAttributes.Class,
                typeof(object),
                new[] { typeof(IMathOperations<T>) });

            // Create the Abs method using IL generation
            CreateAbsMethod(typeBuilder);
            
            // Create the Negate method using IL generation  
            CreateNegateMethod(typeBuilder);

            // Compile the type and instantiate it
            var compiledType = typeBuilder.CreateType()!;
            return (IMathOperations<T>)Activator.CreateInstance(compiledType)!;
        }

        private static void CreateAbsMethod(TypeBuilder typeBuilder)
        {
            var methodBuilder = typeBuilder.DefineMethod(
                "Abs",
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof(T),
                new[] { typeof(T) });

            var il = methodBuilder.GetILGenerator();

            // Try to find and use Math.Abs for this specific type
            var mathAbsMethod = typeof(Math).GetMethod("Abs", new[] { typeof(T) });
            if (mathAbsMethod != null)
            {
                il.Emit(OpCodes.Ldarg_1); // Load the argument
                il.Emit(OpCodes.Call, mathAbsMethod);
            }
            else
            {
                // For types without Math.Abs support, implement manually
                var typeInfo = typeof(T);
                var isSignedType = typeInfo == typeof(sbyte) || typeInfo == typeof(short) || 
                                  typeInfo == typeof(int) || typeInfo == typeof(long) ||
                                  typeInfo == typeof(float) || typeInfo == typeof(double) ||
                                  typeInfo == typeof(decimal);

                if (isSignedType)
                {
                    // Implement: value < 0 ? -value : value
                    var positiveLabel = il.DefineLabel();
                    var endLabel = il.DefineLabel();

                    il.Emit(OpCodes.Ldarg_1); // Load value for comparison
                    il.Emit(OpCodes.Ldc_I4_0); // Load 0 (works for integer types)
                    
                    if (typeInfo == typeof(float) || typeInfo == typeof(double))
                    {
                        il.Emit(OpCodes.Pop); // Remove the int 0
                        if (typeInfo == typeof(float))
                        {
                            il.Emit(OpCodes.Ldc_R4, 0.0f); // Load 0.0f
                        }
                        else
                        {
                            il.Emit(OpCodes.Ldc_R8, 0.0d); // Load 0.0d
                        }
                        il.Emit(OpCodes.Clt); // Compare: value < 0
                    }
                    else if (typeInfo == typeof(long))
                    {
                        il.Emit(OpCodes.Pop); // Remove the int 0
                        il.Emit(OpCodes.Ldc_I8, 0L); // Load 0L
                        il.Emit(OpCodes.Clt); // Compare: value < 0
                    }
                    else
                    {
                        il.Emit(OpCodes.Clt); // Compare: value < 0 (for int, short, sbyte)
                    }

                    il.Emit(OpCodes.Brfalse_S, positiveLabel); // If value >= 0, go to positive label

                    // value < 0, return -value
                    il.Emit(OpCodes.Ldarg_1);
                    il.Emit(OpCodes.Neg);
                    il.Emit(OpCodes.Br_S, endLabel);

                    // value >= 0, return value
                    il.MarkLabel(positiveLabel);
                    il.Emit(OpCodes.Ldarg_1);

                    il.MarkLabel(endLabel);
                }
                else
                {
                    // For unsigned types, abs is just the identity
                    il.Emit(OpCodes.Ldarg_1);
                }
            }

            il.Emit(OpCodes.Ret);
        }

        private static void CreateNegateMethod(TypeBuilder typeBuilder)
        {
            var methodBuilder = typeBuilder.DefineMethod(
                "Negate",
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof(T),
                new[] { typeof(T) });

            var il = methodBuilder.GetILGenerator();

            // Check if the type supports negation by examining if it's signed
            var typeInfo = typeof(T);
            var isSignedType = typeInfo == typeof(sbyte) || typeInfo == typeof(short) || 
                              typeInfo == typeof(int) || typeInfo == typeof(long) ||
                              typeInfo == typeof(float) || typeInfo == typeof(double) ||
                              typeInfo == typeof(decimal);

            if (isSignedType)
            {
                il.Emit(OpCodes.Ldarg_1); // Load the argument
                il.Emit(OpCodes.Neg);     // Negate it using IL neg instruction
            }
            else
            {
                // For unsigned types, throw NotSupportedException
                il.Emit(OpCodes.Ldstr, $"Negate operation is not supported for unsigned type {typeof(T).Name}");
                il.Emit(OpCodes.Newobj, typeof(NotSupportedException).GetConstructor(new[] { typeof(string) })!);
                il.Emit(OpCodes.Throw);
            }

            il.Emit(OpCodes.Ret);
        }
    }

    /// <summary>
    /// <para>Interface for compiled math operations.</para>
    /// <para>Интерфейс для скомпилированных математических операций.</para>
    /// </summary>
    /// <typeparam name="T">
    /// <para>The numeric type.</para>
    /// <para>Числовой тип.</para>
    /// </typeparam>
    public interface IMathOperations<T>
    {
        /// <summary>
        /// <para>Returns the absolute value of the specified number.</para>
        /// <para>Возвращает абсолютное значение указанного числа.</para>
        /// </summary>
        /// <param name="value">
        /// <para>The number to get absolute value for.</para>
        /// <para>Число для получения абсолютного значения.</para>
        /// </param>
        /// <returns>
        /// <para>The absolute value.</para>
        /// <para>Абсолютное значение.</para>
        /// </returns>
        T Abs(T value);

        /// <summary>
        /// <para>Returns the negated value of the specified number.</para>
        /// <para>Возвращает инвертированное значение указанного числа.</para>
        /// </summary>
        /// <param name="value">
        /// <para>The number to negate.</para>
        /// <para>Число для инверсии.</para>
        /// </param>
        /// <returns>
        /// <para>The negated value.</para>
        /// <para>Инвертированное значение.</para>
        /// </returns>
        T Negate(T value);
    }
}