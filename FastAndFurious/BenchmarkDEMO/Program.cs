// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

//var summary = BenchmarkRunner.Run<DotNET10LoopBenchmarks>();

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

[SimpleJob(RuntimeMoniker.Net10_0, baseline: true)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net48)]
[RPlotExporter]
public class DotNET10LoopBenchmarks
{
    [Benchmark]
    public int ForEachIEnumerableSumBenchamrk()
    {
        return 0;
    }
}

[SimpleJob(RuntimeMoniker.Net10_0, baseline: true)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net48)]
[RPlotExporter]
public class DotNET10LoopBenchmarks2
{
    [Benchmark]
    public int ForEachIEnumerableSumBenchamrk()
    {
        return 0;
    }
}