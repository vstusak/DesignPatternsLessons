using System.Collections.Generic;

namespace PublicToilet
{
    public class PublicToiletV2 : IPublicToilet
    {
        private IToiletState _state;
        private IPaymentService _paymentService;
        private readonly IEnumerable<IToiletState> toiletStates;

        public PublicToiletV2(IPaymentService paymentService, IEnumerable<IToiletState> toiletStates)
        {
            //ChangeState(new LockedToiletState());
            _paymentService = paymentService;
            this.toiletStates = toiletStates;
        }

        public void ChangeState(IToiletState state)
            => _state = state;

        public ToiletDoorResult LeaveToilet()
        {
            return _state.LeaveToilet();
        }

        public ToiletDoorResult OpenDoor()
        {
            return _state.OpenDoor();
        }

        public ToiletDoorResult SwipeCard()
        {
            return _state.SwipeCard();
        }
    }
}
