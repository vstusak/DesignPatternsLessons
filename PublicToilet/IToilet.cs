using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet
{
    public interface IToilet
    {
        ToiletDoorResult Enter();
        ToiletDoorResult Leave();
        ToiletDoorResult SwipeCard();
    }
}
