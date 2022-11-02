using CompositePattern2;

var C1_first = new ToDoList() { Name = "C1_first" };

var C2_first = new ToDoList() { Name = "C2_first" };
var C2_second = new ToDoList() { Name = "C2_second" };
var C2_third = new ToDoList() { Name = "C2_third" };

C1_first.AddItem(C2_first);
C1_first.AddItem(C2_second);
C1_first.AddItem(C2_third);

var L3_first = new ToDoList() { Name = "L3_first", IsCompleted = true };
var L3_second = new ToDoList() { Name = "L3_second", IsCompleted = true };
var C3_first = new ToDoList() { Name = "C3_first" };
var C3_second = new ToDoList() { Name = "C3_second", IsCompleted = true };
var L3_third = new ToDoList() { Name = "L3_third" };

C2_first.AddItem(L3_first);
C2_first.AddItem(L3_second);
C2_second.AddItem(C3_first);
C2_second.AddItem(C3_second);
C2_third.AddItem(L3_third);

Console.WriteLine(C1_first.GetString());

//The ToDoItem is not used, it was fully replaced with ToDoList