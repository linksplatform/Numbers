using System;
using Platform.Numbers;

class Program 
{
    static void Main()
    {
        Console.WriteLine("Testing MathHelpers<T> with object methods instead of delegates:");
        
        // Test with int
        Console.WriteLine("\nTesting with int:");
        var intOps = MathHelpers<int>.Operations;
        Console.WriteLine($"Abs(-5) = {intOps.Abs(-5)}");
        Console.WriteLine($"Negate(5) = {intOps.Negate(5)}");
        
        // Test with double
        Console.WriteLine("\nTesting with double:");
        var doubleOps = MathHelpers<double>.Operations;
        Console.WriteLine($"Abs(-3.14) = {doubleOps.Abs(-3.14)}");
        Console.WriteLine($"Negate(3.14) = {doubleOps.Negate(3.14)}");
        
        // Test with uint (unsigned - negate should throw)
        Console.WriteLine("\nTesting with uint (should throw for negate):");
        var uintOps = MathHelpers<uint>.Operations;
        Console.WriteLine($"Abs(5u) = {uintOps.Abs(5u)}");
        
        try 
        {
            Console.WriteLine($"Negate(5u) = {uintOps.Negate(5u)}");
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine($"Expected exception: {ex.Message}");
        }
        
        Console.WriteLine("\nAll tests completed successfully!");
    }
}