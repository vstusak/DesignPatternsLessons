using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern
{
    public static class DataSource
    {
        public static IEnumerable<ExpensiveResult> GetEntities()
        {
            var veryMuchExpensiveStuff = new List<ExpensiveResult>();

            for (int i = 1; i < 50; i++)
            {
                veryMuchExpensiveStuff.Add(new ExpensiveResult { Text = i.ToString() });
            }

            return veryMuchExpensiveStuff;
        }
    }
}
