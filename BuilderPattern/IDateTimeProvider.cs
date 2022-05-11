using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
