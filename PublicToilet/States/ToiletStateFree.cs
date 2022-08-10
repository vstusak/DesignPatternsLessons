using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet.States
{
    public class ToiletStateFree: IToiletState
    {
        private const ToiletState _state = ToiletState.Free;

        public ToiletDoorResult Enter()
        {
            return new ToiletDoorResult { DisplayText = "Free.", ToiletState = _state };
        }

        public ToiletDoorResult Leave()
        {
            throw new NotImplementedException();
        }

        public ToiletDoorResult SwipeCard()
        {
            throw new NotImplementedException();
        }
    }
}
