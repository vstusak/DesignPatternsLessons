using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet.States
{
    public class ToiletStatePaid:IToiletState
    {
        private IToiletV2 _toilet;

        public ToiletStatePaid(IToiletV2 toilet)
        {
            _toilet = toilet;
        }

        public ToiletState State => ToiletState.Paid;

        public ToiletDoorResult Enter()
        {
            _toilet.ChangeStateObject(new ToiletStateOccupied(_toilet));
            return new ToiletDoorResult { DisplayText = "Occupied.", ToiletState = ToiletState.Occupied };
        }

        public ToiletDoorResult Leave()
        {
            return new ToiletDoorResult { DisplayText = "You can enter.", ToiletState = State };
        }

        public ToiletDoorResult SwipeCard()
        {
            return new ToiletDoorResult { DisplayText = "You can enter.", ToiletState = State };
        }
    }
}
