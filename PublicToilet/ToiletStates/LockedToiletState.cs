using System;
using System.Drawing;

namespace PublicToilet
{
    public class LockedToiletState : IToiletState
    {
        private PublicToiletV2 _publicToiletV2;
        private IPaymentService _paymentService;

        public LockedToiletState(IPaymentService paymentService)
        {
            this._publicToiletV2 = _publicToiletV2;
            _paymentService = paymentService;
        }

        public State NameOfState => State.Locked;

        public ToiletDoorResult LeaveToilet()
        {
            _publicToiletV2.ChangeState(this);
            return new ToiletDoorResult("Door locked", Color.Red);
        }
        public ToiletDoorResult OpenDoor()
        {
            _publicToiletV2.ChangeState(this);
            return new ToiletDoorResult("Door locked", Color.Red);
        }
        public ToiletDoorResult SwipeCard()
        {
            if (_paymentService.Pay())
            {
                _publicToiletV2.ChangeState(this);
                return new ToiletDoorResult("Payment failed", Color.Red);
            }

            _publicToiletV2.ChangeState(new UnlockedToiletState(_publicToiletV2));
            return new ToiletDoorResult("Door opened", Color.Green);
        }
    }
}
