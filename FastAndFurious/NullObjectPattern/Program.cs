using NullObjectPattern;

var factory = new CalculatorFactory();

var calcType = Console.ReadLine();

var calc = factory.Create(calcType);

var result = calc.Add(1, 1);

Console.WriteLine(result);

//Calculator calc2 = null;

////calc2?.GetType() == typeof(Calculator)
////if (calc2 is Calculator)

//try
//{
//    var calc3 = (Calculator)calc2; //as Calculator;
//    var calc4 = (IScienceCalculator)calc2; //as ScienceCalculator;
//    Console.WriteLine("WORKING");
//}
//catch (Exception e)
//{
//    Console.WriteLine(e);
//}



////Console.WriteLine(calc2.GetType());