using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet
{
    public class PaymentFailedToiletState : IToiletState
    {
        private PublicToiletV2 publicToiletV2;

        public PaymentFailedToiletState(PublicToiletV2 publicToiletV2)
        {
            this.publicToiletV2 = publicToiletV2;
        }

        public ToiletDoorResult LeaveToilet()
        {
            throw new NotImplementedException();
        }

        public ToiletDoorResult OpenDoor()
        {
            throw new NotImplementedException();
        }

        public ToiletDoorResult SwipeCard()
        {
            throw new NotImplementedException();
        }
    }
}
