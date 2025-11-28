// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;


const int Iters = 10_000_000;

Console.WriteLine("runnnig...");

var values = Enumerable.Range(0, 100).ToList();

Stopwatch sw = new();



while (true)
{
    long mem = GC.GetAllocatedBytesForCurrentThread();
    sw.Restart();

    for (int i = 0; i < Iters; i++)
    {
        //Test();
        //Test2("A", "B", "C");
        //Test3(values);
        //Test4(values);
        Test5(values);
    }

    sw.Stop();

    mem = GC.GetAllocatedBytesForCurrentThread() - mem;

    Console.WriteLine($"{(sw.Elapsed.TotalSeconds * 1_000_000_000) / Iters:N0} ns, {mem / Iters:N0} bytes");
}

[MethodImpl(MethodImplOptions.NoInlining)]
static TimeSpan Test()
{
    Stopwatch sw = Stopwatch.StartNew();
    sw.Stop();
    return sw.Elapsed;
}


[MethodImpl(MethodImplOptions.NoInlining)]
static int Test2(string a, string b, string c)
{
    int summary = 0;

    foreach (string item in new[]{ a,b,c })
    {
        summary += item.Length;
    }

    return summary; 
}

[MethodImpl(MethodImplOptions.NoInlining)]
static int Test3(int[] values)
{
    int summary = 0;

    foreach (int item in values)
    {
        summary += item;
    }

    return summary;
}

[MethodImpl(MethodImplOptions.NoInlining)]
static int Test4(IEnumerable<int> values)
{
    int summary = 0;

    foreach (int item in values)
    {
        summary += item;
    }

    return summary;
}

[MethodImpl(MethodImplOptions.NoInlining)]
static int Test5(List<int> values)
{
    int summary = 0;

    foreach (int item in values)
    {
        summary += item;
    }

    return summary;
}