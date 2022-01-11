using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet
{
    public class UnlockedToiletState : IToiletState
    {
        private readonly PublicToiletV2 publicToiletV2;

        public UnlockedToiletState(PublicToiletV2 publicToiletV2)
        {
            this.publicToiletV2 = publicToiletV2;
        }

        public State NameOfState => State.Unlocked;

        public ToiletDoorResult LeaveToilet()
        {
            publicToiletV2.ChangeState(new LockedToiletState(publicToiletV2));
            return new ToiletDoorResult("Door locked", Color.Red);
        }
        public ToiletDoorResult OpenDoor()
        {
            publicToiletV2.ChangeState(new OccupiedToiletState(publicToiletV2));
            return new ToiletDoorResult("Occupied", Color.Orange);
        }
        public ToiletDoorResult SwipeCard()
        {
            publicToiletV2.ChangeState(this);
            return new ToiletDoorResult("Door already opened, go in and do it", Color.Green);
        }
    }
}
