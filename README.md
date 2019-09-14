[![NuGet Version and Downloads count](https://buildstats.info/nuget/Platform.Hardware.Cpu)](https://www.nuget.org/packages/Platform.Hardware.Cpu)
[![Build Status](https://travis-ci.com/linksplatform/Hardware.Cpu.svg?branch=master)](https://travis-ci.com/linksplatform/Hardware.Cpu)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/c07241e87f0a4441a8cd9664e0b6fadc)](https://app.codacy.com/app/drakonard/Hardware.Cpu?utm_source=github.com&utm_medium=referral&utm_content=linksplatform/Hardware.Cpu&utm_campaign=Badge_Grade_Dashboard)
[![CodeFactor](https://www.codefactor.io/repository/github/linksplatform/Hardware.Cpu/badge)](https://www.codefactor.io/repository/github/linksplatform/Hardware.Cpu)

# [Hardware.Cpu](https://github.com/linksplatform/Hardware.Cpu)

LinksPlatform's Platform.Hardware.Cpu Class Library.

Namespace: [Platform.Hardware.Cpu](https://linksplatform.github.io/Hardware.Cpu/api/Platform.Hardware.Cpu.html)

Forked from: [Konard/LinksPlatform/Platform/Platform.Helpers/Hardware.Cpu](https://github.com/Konard/LinksPlatform/tree/19902d5c6221b5c93a5e06849de28bb97edac5f8/Platform/Platform.Helpers/Hardware.Cpu)

NuGet package: [Platform.Hardware.Cpu](https://www.nuget.org/packages/Platform.Hardware.Cpu)

## Example
```csharp
using System;
using Platform.Hardware.Cpu;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(CacheLine.Size); // Print the cache line size in bytes
        
        var array = new CacheLineAlignedArray<string>(10);
        Interlocked.Exchange(ref array[0], "Hello"); // All threads can now see the latest value at `array[0]` without risk of ruining performance with false-sharing

        // This can be used to build collections which share elements across threads at the fastest possible synchronization.
    }
    
    // An array-like type where each element is on it's own cache-line. This is a building block for avoiding false-sharing.
    public struct CacheLineAlignedArray<T> where T : class {
        private readonly T[] buffer;
        public CacheLineAlignedArray(Int32 size) => buffer = new T[Multiplier * size];
        public Int32 Length => buffer.Length / Multiplier;
        public ref T this[Int32 index] => ref buffer[Multiplier * index];
        private static readonly Int32 Multiplier = CacheLine.Size / IntPtr.Size;
    }
}
```

## [Documentation](https://linksplatform.github.io/Hardware.Cpu)
[PDF file](https://linksplatform.github.io/Hardware.Cpu/Platform.Hardware.Cpu.pdf) with code for e-readers.

## Dependent libraries
*   [Platform.Unsafe](https://github.com/linksplatform/Unsafe)

## See also
- [NickStrupat/CacheLineSize.NET](https://github.com/NickStrupat/CacheLineSize.NET) for the equivalent .NET Standard library (without .NET Framework support)
- [NickStrupat/CacheLineSize](https://github.com/NickStrupat/CacheLineSize) for the equivalent C function
- [ulipollo/CacheLineSizeMex](https://github.com/ulipollo/CacheLineSizeMex) for the MATLAB function

## Mystery files
*   [.travis.yml](https://github.com/linksplatform/Hardware.Cpu/blob/master/.travis.yml) - [Travis CI](https://travis-ci.com) build configuration.
*   [docfx.json](https://github.com/linksplatform/Hardware.Cpu/blob/master/docfx.json) and [toc.yml](https://github.com/linksplatform/Hardware.Cpu/blob/master/toc.yml) - [DocFX](https://dotnet.github.io/docfx) build configuration.
*   [format-document.sh](https://github.com/linksplatform/Hardware.Cpu/blob/master/format-document.sh) - script for formatting `tex` file for generating PDF from it.
*   [format-csharp-files.py](https://github.com/linksplatform/Hardware.Cpu/blob/master/format-csharp-files.py) - script for formatting `.cs` files as a part of `tex` file.
*   [generate-pdf.sh](https://github.com/linksplatform/Hardware.Cpu/blob/master/generate-pdf.sh) - script that generates PDF with code for e-readers.
*   [publish-docs.sh](https://github.com/linksplatform/Hardware.Cpu/blob/master/publish-docs.sh) - script that publishes generated documentation and PDF with code for e-readers to [gh-pages](https://github.com/linksplatform/Hardware.Cpu/tree/gh-pages) branch.
*   [push-nuget.sh](https://github.com/linksplatform/Hardware.Cpu/blob/master/push-nuget.sh) - script for publishing current version of [NuGet](https://www.nuget.org) package.
