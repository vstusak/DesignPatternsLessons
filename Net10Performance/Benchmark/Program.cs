// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

//var summary = BenchmarkRunner.Run<BenchmarkNet10LoopPerformance>();
var summary = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

/*[SimpleJob(RuntimeMoniker.Net10_0)]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net481)]
*/
[RPlotExporter]
public class BenchmarkNet10LoopPerformance
{
    [Benchmark]
    public int ForEachEnumerable()
    {

        return 0;
    }
    [Benchmark]
    public int ForEachEnumerableTwo()
    {

        return 0;
    }
}