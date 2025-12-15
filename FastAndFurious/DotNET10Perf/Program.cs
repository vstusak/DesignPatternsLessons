// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics.Tensors;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
//var valuesDict = new ConcurrentDictionary<int, string>(Enumerable.Range(0, 100).Select(e => new KeyValuePair<int, string>(e, e.ToString())));
var valuesLinq = Enumerable.Range(0, 100).Reverse();
var bits1 = new BitArray(1024, false);
var bits2 = new BitArray(1024, true);

#if NET10_0
    Console.WriteLine(string.Join(' ', valuesLinq.ToList().Shuffle()));

#else
    var random = new Random(DateTime.Now.Microsecond);
    Console.WriteLine(string.Join(' ', valuesLinq.ToList()));
    var randomList = valuesLinq.OrderBy(item => random.Next()); // Generuje náhodné číslo pro každý prvek .ToList()
    Console.WriteLine(string.Join(' ', randomList.ToList()));
#endif
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
        //Test8(valuesDict);
        //Test9(bits1, bits2);
        Test10(valuesLinq);
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

[MethodImpl(MethodImplOptions.NoInlining)]
static long Test9(BitArray bits1, BitArray bits2)
{
    // Hamming distance calculation -count of different bits between two bit arrays
    #if NET10_0
        return TensorPrimitives.HammingBitDistance<byte>(
            CollectionsMarshal.AsBytes(bits1), //in .net10 there is new API to get byte representation of BitArray without allocations
            CollectionsMarshal.AsBytes(bits2));
    #else
        long distance = 0;
        for (int i = 0; i < bits1.Length; i++)
        {
            if (bits1[i] != bits2[i])
            {
                distance++;
            }
        }

        return distance;

    #endif
}

[MethodImpl(MethodImplOptions.NoInlining)]
static bool Test10(IEnumerable<int> queue)
{
    return queue.Contains(42);
}
