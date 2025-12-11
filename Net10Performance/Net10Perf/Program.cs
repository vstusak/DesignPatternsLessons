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

// Optimization of c# code:
// https://lab.razor.fyi/#xZBNSkMxFIVRpGhG4goujp4Uojh9diAV_KGK0IKgCMb0-noxL9Hc-6oi3YV7cAPuwC04cB2uQF77qLX4NzOj5JwvJ_dEPdeUOowhiybXlpeeagWTz6B9x4J5qiZPuhmcQysUPOtt9BjJ_kDs5nkh5tzhFLNFJvOBhSx_7-hm6OKmN-6OaRprkb-ekjq9iKZLPvtO1x3Dl5wqZZ1hhqqxulcAACxGyEI_UBf2DflkZSiPzHI1g-fgUB9FEmyRx2R5B50LenklHUIDpWAyirxAB1kS8nJyCn3jCuTp1NXVvonAEq6OjNgeNKAt4eqm3Ou2mCgHeJNUD4z4MatLctIbJhU5NGAtVWP1IkQ0tpeULgH5T4N8HmY4fJFDvQH0EVv2qlZEKaIvmaryl4XX_79xMmpb6kCwUY2iW-gz6aVA9fov_UcXTuj0b_-gBmpv1vLxwvzb48PL68Xi3NnM7cw7


// --== Useful code ==--

const int Iters = 10_000_00;
//var values = Enumerable.Range(0, 100).ToList();
//var values = new Stack<int>(Enumerable.Range(0, 100));
//var values = new Queue<int>(Enumerable.Range(0, 100));
//var values = new ConcurrentDictionary<int, int>(Enumerable.Range(0, 100).Select(e => new KeyValuePair<int, int>(e,e)));
var values1 = new BitArray(1024, false);
var values2 = new BitArray(1024, true);
var values3 = Enumerable.Range(0, 100).Shuffle(); //.Reverse(); //.OrderBy(x => -x);

Console.WriteLine(string.Join(" ", values3));


Console.WriteLine("running...");

Stopwatch sw = new();

while (true)
{
    long mem = GC.GetAllocatedBytesForCurrentThread();
    sw.Restart();
    
    for (int i = 0; i < Iters; i++)
    {
        //Test(values1, values2);
        TestLinq(values3);
    }

    sw.Stop();

    mem = GC.GetAllocatedBytesForCurrentThread() - mem;

    Console.WriteLine($"{(sw.Elapsed.TotalSeconds * 1_000_000_000) / Iters:N0} ns, {mem / Iters:N0} bytes");
}


[MethodImpl(MethodImplOptions.NoInlining)] // prevent inlining to get more accurate measurements
static int TestLinq(IEnumerable<int> values)
{
    return values.First();
    //return values.Contains(35);
}



//[MethodImpl(MethodImplOptions.NoInlining)] // prevent inlining to get more accurate measurements
//static long Test(BitArray values1, BitArray values2)
//{
//#if NET10_0
//    return TensorPrimitives.HammingBitDistance<byte>(
//    CollectionsMarshal.AsBytes(values1),
//    CollectionsMarshal.AsBytes(values2));
//#else
//    //var stopWatch = Stopwatch.StartNew();
//    //stopWatch.Stop();
//    var distance = 0;

//    for (int i = 0; i < values1.Length; i++)
//    {
//        if(values1[i] != values2[i])
//        { 
//            distance++; 
//        }
//    }

//    return distance;
//#endif

//    //foreach(var i in values)
//    //{
//    //    distance += i.Value;
//    //}

//    //return distance;
//}

