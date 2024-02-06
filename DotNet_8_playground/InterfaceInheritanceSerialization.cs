//using System.Text.Json;

//IDerived value = new DerivedImplement { Base = 0, Derived = 1 };
//var serialize = JsonSerializer.Serialize(value);
//Console.WriteLine(serialize);
//// {"Base":0,"Derived":1}

//public interface IBase
//{
//    public int Base { get; set; }
//}

//public interface IDerived : IBase
//{
//    public int Derived { get; set; }
//}

//public class DerivedImplement : IDerived
//{
//    public int Base { get; set; }
//    public int Derived { get; set; }
//}