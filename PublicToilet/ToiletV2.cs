using PublicToilet.ObserverDesignPattern;
using PublicToilet.States;

namespace PublicToilet
{
    public class ToiletV2:IToiletV2
    {
        private IToiletState _toiletStateObject;
        private List<IToiletObserver> toiletObservers = new();

        public ToiletV2()
        {
            _toiletStateObject = new ToiletStateFree(this);
        }

        public ToiletDoorResult Enter()
        {
            return _toiletStateObject.Enter();
        }

        public ToiletDoorResult Leave()
        {
            return _toiletStateObject.Leave();
        }

        public ToiletDoorResult SwipeCard()
        {
            return _toiletStateObject.SwipeCard();
        }

        public void ChangeStateObject(IToiletState toiletState)
        {
            _toiletStateObject = toiletState;
            NotifyAll();
        }

        public Unsubscriber AddObserver(IToiletObserver toiletObserver)
        {
            toiletObservers.Add(toiletObserver);
            return new Unsubscriber(toiletObservers, toiletObserver);
        }

        public void NotifyAll()
        {
            foreach(var observer in toiletObservers)
            {
                observer.Update();
            }
        }

        public string GetState()
        {
            return $"[{DateTime.Now}] {_toiletStateObject.State}";
        }
    }
}
