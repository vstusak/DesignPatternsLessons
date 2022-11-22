using System.Collections.Generic;
using System.ComponentModel;
using PublicToilet.ObservatorDesignPattern;

namespace PublicToilet
{
    public class PublicToiletV2 : IPublicToilet, IOurObservable
    {
        private IToiletState _state;
        private IPaymentService _paymentService;
        private readonly IEnumerable<IToiletState> toiletStates;
        public readonly List<IOurObserver> _observers = new();
        //public readonly BindingList<IOurObserver> _observers = new();

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
            foreach (var observer in _observers)
            {
                observer.NotificationRaised(this);
            }
        }

        public State GetState()
        {
            return _state.NameOfState;
        }
    }
}
