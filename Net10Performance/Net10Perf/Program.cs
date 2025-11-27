// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

// Optimization of c# code:
// https://lab.razor.fyi/#xZBNSkMxFIVRpGhG4goujp4Uojh9diAV_KGK0IKgCMb0-noxL9Hc-6oi3YV7cAPuwC04cB2uQF77qLX4NzOj5JwvJ_dEPdeUOowhiybXlpeeagWTz6B9x4J5qiZPuhmcQysUPOtt9BjJ_kDs5nkh5tzhFLNFJvOBhSx_7-hm6OKmN-6OaRprkb-ekjq9iKZLPvtO1x3Dl5wqZZ1hhqqxulcAACxGyEI_UBf2DflkZSiPzHI1g-fgUB9FEmyRx2R5B50LenklHUIDpWAyirxAB1kS8nJyCn3jCuTp1NXVvonAEq6OjNgeNKAt4eqm3Ou2mCgHeJNUD4z4MatLctIbJhU5NGAtVWP1IkQ0tpeULgH5T4N8HmY4fJFDvQH0EVv2qlZEKaIvmaryl4XX_79xMmpb6kCwUY2iW-gz6aVA9fov_UcXTuj0b_-gBmpv1vLxwvzb48PL68Xi3NnM7cw7


// --== Useful code ==--

const int Iters = 10_000_000;
int[] values = Enumerable.Range(0, 100).ToArray();

Console.WriteLine("runnnig...");

Stopwatch sw = new();

while (true)
{
    long mem = GC.GetAllocatedBytesForCurrentThread();
    sw.Restart();
    
    for (int i = 0; i < Iters; i++)
    {
        Test(values);
    }

    sw.Stop();

    mem = GC.GetAllocatedBytesForCurrentThread() - mem;

    Console.WriteLine($"{(sw.Elapsed.TotalSeconds * 1_000_000_000) / Iters:N0} ns, {mem / Iters:N0} bytes");
}


[MethodImpl(MethodImplOptions.NoInlining)] // prevent inlining to get more accurate measurements
static int Test(int[] values)
{
    //var stopWatch = Stopwatch.StartNew();
    //stopWatch.Stop();
    var sum = 0;

    foreach(var i in values)
    {
        sum += i;
    }

    return sum;
}

