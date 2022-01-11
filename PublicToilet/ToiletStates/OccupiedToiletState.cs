using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet
{
    public class OccupiedToiletState : IToiletState
    {
        private PublicToiletV2 publicToiletV2;

        public OccupiedToiletState(PublicToiletV2 publicToiletV2)
        {
            this.publicToiletV2 = publicToiletV2;
        }

        public State NameOfState => State.Occupied;

        public ToiletDoorResult LeaveToilet()
        {
            publicToiletV2.ChangeState(new LockedToiletState(publicToiletV2));
            return new ToiletDoorResult("Door locked", Color.Red);
        }

        public ToiletDoorResult OpenDoor()
        {
            publicToiletV2.ChangeState(this);
            return new ToiletDoorResult("Toiled is occupied", Color.Red);
        }

        public ToiletDoorResult SwipeCard()
        {
            publicToiletV2.ChangeState(this);
            return new ToiletDoorResult("Toiled is occupied", Color.Red);
        }
    }
}
