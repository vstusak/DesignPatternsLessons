using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicToilet.States;

namespace PublicToilet
{
    public class ToiletV2:IToilet
    {
        private IToiletState _toiletStateObject= new ToiletStateFree();

        public ToiletDoorResult Enter()
        {
            return _toiletStateObject.Enter();
        }

        public ToiletDoorResult Leave()
        {
            return _toiletStateObject.Leave();
        }

        public ToiletDoorResult SwipeCard()
        {
            return _toiletStateObject.SwipeCard();
        }
    }
}
