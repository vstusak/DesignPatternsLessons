namespace PublicToilet
{
    public interface IToiletState
    {
        State NameOfState { get; }
        ToiletDoorResult SwipeCard();
        ToiletDoorResult OpenDoor();
        ToiletDoorResult LeaveToilet();
    }
}
