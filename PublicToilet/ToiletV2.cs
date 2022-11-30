using PublicToilet.States;

namespace PublicToilet
{
    public class ToiletV2:IToiletV2
    {
        private IToiletState _toiletStateObject;

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
        }
    }
}
