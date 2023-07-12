using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChatApplication.Positions
{
    public class Leader : Person
    {
        public Leader(string name)
        {
            Name = name;
            PositionType = PositionType.Leader;
        }
    }
}
