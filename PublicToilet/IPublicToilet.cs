namespace PublicToilet
{
    public interface IPublicToilet
    {
        ToiletDoorResult LeaveToilet();
        ToiletDoorResult OpenDoor();
        ToiletDoorResult SwipeCard();
    }
}