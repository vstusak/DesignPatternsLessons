// See https://aka.ms/new-console-template for more information
using CompositePatternTodoList;

Console.WriteLine("Hello, World!");

var L5_first = new TodoItem("L5_first", string.Empty);
var L5_second = new TodoItem("L5_second", string.Empty);
var C4_first = new TodoCompositeItem("C4_first", string.Empty);
C4_first.Add(L5_first);
C4_first.Add(L5_second);

var L5_third = new TodoItem("L5_third", string.Empty);
var C4_second = new TodoCompositeItem("C4_second", string.Empty);
C4_second.Add(L5_third);

var L4_first = new TodoItem("L4_first", string.Empty);
var L4_second = new TodoItem("L4_second", string.Empty);
var C3_first = new TodoCompositeItem("C3_first", string.Empty);
C3_first.Add(L4_first);
C3_first.Add(L4_second);

var C3_second = new TodoCompositeItem("C3_second", string.Empty);
C3_second.Add(C4_first);
C3_second.Add(C4_second);
C3_second.IsDone = true;

var C2_second = new TodoCompositeItem("C2_second", string.Empty);
C2_second.Add(C3_first);
C2_second.Add(C3_second);

var L3_first = new TodoItem("L3_first", string.Empty);
var L3_second = new TodoItem("L3_second", string.Empty);
var C2_first = new TodoCompositeItem("C2_first", string.Empty);
C2_first.Add(L3_first);
C2_first.Add(L3_second);


var L3_third = new TodoItem("L3_third", string.Empty);
var C2_third = new TodoCompositeItem("C2_third", string.Empty);
C2_third.Add(L3_third);

var L2_first = new TodoItem("L2_first", string.Empty);
var C1_first = new TodoCompositeItem("C1_first", string.Empty);
C1_first.Add(C2_first);
C1_first.Add(C2_second);
C1_first.Add(C2_third);
C1_first.Add(L2_first);

Console.WriteLine(C1_first.GetString());
Console.ReadLine();