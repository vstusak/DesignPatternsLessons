﻿namespace ProxyPattern
{
    public class ExpensiveResult
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
