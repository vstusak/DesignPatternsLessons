using System;
using System.Collections.Generic;

namespace ProxyPattern
{
    public static class DataSource
    {
        public static IEnumerable<ExpensiveResult> GetEntities()
        {
            Console.WriteLine("Getting data from DataSource...");
            var veryMuchExpensiveStuff = new List<ExpensiveResult>();

            for (int i = 1; i < 50; i++)
            {
                veryMuchExpensiveStuff.Add(new ExpensiveResult { Text = i.ToString() });
            }

            return veryMuchExpensiveStuff;
        }
    }
}
