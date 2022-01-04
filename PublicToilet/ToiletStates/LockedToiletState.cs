using System;
using System.Drawing;

namespace PublicToilet
{
    public class LockedToiletState : IToiletState
    {
        private PublicToiletV2 publicToiletV2;

        public LockedToiletState(PublicToiletV2 publicToiletV2)
        {
            this.publicToiletV2 = publicToiletV2;
        }

        public ToiletDoorResult LeaveToilet()
        {
            publicToiletV2.ChangeState(this);
            return new ToiletDoorResult("Door locked", Color.Red);
        }
        public ToiletDoorResult OpenDoor()
        {
            publicToiletV2.ChangeState(this);
            return new ToiletDoorResult("Door locked", Color.Red);
        }
        public ToiletDoorResult SwipeCard()
        {
            if (!PaymentService.Pay())
            {
                publicToiletV2.ChangeState(new PaymentFailedToiletState(publicToiletV2));
                return new ToiletDoorResult("Payment failed", Color.Red);
            }

            publicToiletV2.ChangeState(new UnlockedToiletState(publicToiletV2));
            return new ToiletDoorResult("Door opened", Color.Green);
        }
    }
}
