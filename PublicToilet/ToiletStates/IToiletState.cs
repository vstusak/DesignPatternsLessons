namespace PublicToilet
{
    public interface IToiletState
    {
        ToiletDoorResult SwipeCard();
        ToiletDoorResult OpenDoor();
        ToiletDoorResult LeaveToilet();
    }
}
