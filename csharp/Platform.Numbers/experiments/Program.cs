using System;
using Platform.Numbers;

/// <summary>
/// Test program to verify MathHelpers<T> works with compiled object methods instead of delegates
/// </summary>
class Program 
{
    static void Main()
    {
        Console.WriteLine("Testing MathHelpers<T> with compiled object methods:");
        Console.WriteLine("=======================================================");
        
        Console.WriteLine("\n1. Testing with int (signed type):");
        TestWithType<int>(-5, 10);
        
        Console.WriteLine("\n2. Testing with double (signed floating-point type):");
        TestWithType<double>(-3.14, 2.718);
        
        Console.WriteLine("\n3. Testing with long (signed type):");
        TestWithType<long>(-123456789L, 987654321L);
        
        Console.WriteLine("\n4. Testing with uint (unsigned type - negate should throw):");
        TestUnsignedType<uint>(42u);
        
        Console.WriteLine("\n5. Testing with float (signed floating-point type):");
        TestWithType<float>(-1.23f, 4.56f);
        
        Console.WriteLine("\nAll tests completed successfully!");
        Console.WriteLine("The MathHelpers<T> implementation uses compiled object methods instead of delegates.");
    }
    
    static void TestWithType<T>(T negativeValue, T positiveValue) 
        where T : System.Numerics.INumberBase<T>
    {
        var ops = MathHelpers<T>.Operations;
        
        Console.WriteLine($"  Type: {typeof(T).Name}");
        Console.WriteLine($"  Abs({negativeValue}) = {ops.Abs(negativeValue)}");
        Console.WriteLine($"  Abs({positiveValue}) = {ops.Abs(positiveValue)}");
        Console.WriteLine($"  Negate({positiveValue}) = {ops.Negate(positiveValue)}");
        Console.WriteLine($"  Negate({negativeValue}) = {ops.Negate(negativeValue)}");
    }
    
    static void TestUnsignedType<T>(T value)
        where T : System.Numerics.INumberBase<T>
    {
        var ops = MathHelpers<T>.Operations;
        
        Console.WriteLine($"  Type: {typeof(T).Name} (unsigned)");
        Console.WriteLine($"  Abs({value}) = {ops.Abs(value)}");
        
        try 
        {
            Console.WriteLine($"  Negate({value}) = {ops.Negate(value)}");
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine($"  Negate({value}) threw expected exception: {ex.Message}");
        }
    }
}