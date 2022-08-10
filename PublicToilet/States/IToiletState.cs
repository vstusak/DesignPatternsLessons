using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet.States
{
    public interface IToiletState
    {
        ToiletDoorResult Enter();
        ToiletDoorResult Leave();
        ToiletDoorResult SwipeCard();
    }
}
