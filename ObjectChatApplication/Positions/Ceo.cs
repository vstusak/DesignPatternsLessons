using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChatApplication.Positions
{
    public class Ceo : Person
    {
        public Ceo(string name)
        {
            Name = name;
            PositionType = PositionType.Ceo;
        }
    }
}
