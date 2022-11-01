using System.Collections.Generic;
using PublicToilet.ObservatorDesignPattern;

namespace PublicToilet
{
    public class PublicToiletV2 : IPublicToilet, IOurObservable
    {
        private IToiletState _state;
        private IPaymentService _paymentService;
        private readonly IEnumerable<IToiletState> toiletStates;
        private readonly List<IOurObserver> _observers = new List<IOurObserver>();

        public PublicToiletV2()
        {
            _state = new LockedToiletState(this);
            _paymentService = new PaymentService();
            //this.toiletStates = toiletStates;
        }

        public void ChangeState(IToiletState state)
        {
            if (state.NameOfState != _state.NameOfState)
            {
                _state = state;
                NotifyAll();
            }
        }

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

        public IOurUnSubscriber Subscribe(IOurObserver observer)
        {
            _observers.Add(observer);
            return new UnSubscriber(_observers, observer);
        }

        public void NotifyAll()
        {
            _observers.ForEach(o => o.NotificationRaised(this));
        }

        public State GetState()
        {
            return _state.NameOfState;
        }
    }
}
