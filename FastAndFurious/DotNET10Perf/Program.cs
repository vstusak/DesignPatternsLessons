// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

/**
 * dotnet run -c Release -f net48
 * dotnet run -c Release -f net9.0
 * dotnet run -c Release -f net10.0
 */

const int Iters = 10_000_000;

Console.WriteLine("runnnig...");

//var values = Enumerable.Range(0, 100).ToList();
//var stack = new Stack<int>(Enumerable.Range(0, 100));
//var queue = new Queue<int>(Enumerable.Range(0, 100));
var valuesDict = new ConcurrentDictionary<int, string>(Enumerable.Range(0, 100).Select(e => new KeyValuePair<int, string>(e, e.ToString())));

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
        //Test5(values);
        //Test6(stack);
        //Test7(queue);
        Test8(valuesDict);
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

[MethodImpl(MethodImplOptions.NoInlining)]
//static int Test6(Stack<int> stack)
static int Test6(IEnumerable<int> stack)
{
    int summary = 0;

    foreach (int item in stack)
    {
        summary += item;
    }

    return summary;
}

[MethodImpl(MethodImplOptions.NoInlining)]
//static int Test7(Queue<int> queue)
static int Test7(IEnumerable<int> queue)
{
    int summary = 0;

    foreach (int item in queue)
    {
        summary += item;
    }

    return summary;
}

[MethodImpl(MethodImplOptions.NoInlining)]
//static int Test8(ConcurrentDictionary<int, int> dict)
static int Test8(IEnumerable<KeyValuePair<int, string>> dict)
{
    int summary = 0;

    foreach (var item in dict)
    {
        summary += item.Key;
    }

    return summary;
}