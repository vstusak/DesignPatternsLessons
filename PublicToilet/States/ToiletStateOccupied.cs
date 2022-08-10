using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet.States
{
    public class ToiletStateOccupied: IToiletState
    {
        private IToiletV2 _toilet;

        public ToiletStateOccupied(IToiletV2 toilet)
        {
            _toilet = toilet;
        }

        private const ToiletState _state = ToiletState.Occupied;

        public ToiletDoorResult Enter()
        {
            return new ToiletDoorResult { DisplayText = "Occupied.", ToiletState = _state };
        }

        public ToiletDoorResult Leave()
        {
            _toilet.ChangeStateObject(new ToiletStateFree(_toilet));
            return new ToiletDoorResult { DisplayText = "Free.", ToiletState = ToiletState.Free };
        }

        public ToiletDoorResult SwipeCard()
        {
            return new ToiletDoorResult { DisplayText = "Occupied.", ToiletState = _state };
        }
    }
}
