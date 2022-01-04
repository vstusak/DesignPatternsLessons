namespace PublicToilet
{
    public class PublicToiletV2 : IPublicToilet
    {
        private IToiletState _state;

        public PublicToiletV2()
        {
            ChangeState(new LockedToiletState(this));
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
