using System.Collections.Generic;
using PublicToilet.ObservatorDesignPattern;

namespace PublicToilet
{
    public class PublicToiletV2 : IPublicToilet, IOurObservable
    {
        private IToiletState _state;
        private IPaymentService _paymentService;
        private readonly IEnumerable<IToiletState> toiletStates;
        private readonly IList<IOurObserver> _observers = new List<IOurObserver>();

        public PublicToiletV2(IPaymentService paymentService, IEnumerable<IToiletState> toiletStates)
        {
            //ChangeState(new LockedToiletState());
            _paymentService = paymentService;
            this.toiletStates = toiletStates;
        }

        public void ChangeState(IToiletState state)
        {
            if (state.NameOfState != _state.NameOfState)
            {
                NotifyAll();
            }
            _state = state;
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
            return new UnSubscriber();
        }

        public void NotifyAll()
        {
            @TODO Run application
            throw new System.NotImplementedException();
        }

        public State GetState()
        {
            throw new System.NotImplementedException();
        }
    }
}
