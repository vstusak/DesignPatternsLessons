using System.Collections.Frozen;
using System.Diagnostics;
using Net8newFeatures;

var dictionary = new Dictionary<string, object>();
var source = new []{ "jedna", "dva", "tri", "ctyri", "pet" };
var searchedKey = "12330";

var stopWatch = new Stopwatch();
var stopWatch2 = new Stopwatch();

for (int i = 0; i < 10000; i++)
{
    dictionary[i.ToString()] = Random.Shared.GetItems(source, 1);
}

var frozen = dictionary.ToFrozenDictionary();

stopWatch.Start();
//var search = dictionary[searchedKey];
stopWatch.Stop();

Console.WriteLine($"Dictionary: {stopWatch.ElapsedTicks}");

stopWatch2.Start();
//var search2 = frozen[searchedKey];
stopWatch2.Stop();

Console.WriteLine($"Frozen: {stopWatch2.ElapsedTicks}");

stopWatch.Reset();
stopWatch2.Reset();

stopWatch.Start();
dictionary.TryGetValue(searchedKey, out object setting);
stopWatch.Stop();

Console.WriteLine($"Dictionary: {stopWatch.ElapsedTicks}");

stopWatch2.Start();
frozen.TryGetValue(searchedKey, out object setting2);
stopWatch2.Stop();

Console.WriteLine($"Frozen: {stopWatch2.ElapsedTicks}");

