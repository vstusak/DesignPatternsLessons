using System.Drawing;

namespace PublicToilet
{
    public class PublicToilet
    {
        private State _toiletState = State.Locked;

        public ToiletDoorResult SwipeCard()
        {
            if (_toiletState == State.Occupied)
            {
                return new ToiletDoorResult( "Transaction isn't done", Color.Orange);
            }

            if (!PaymentService.Pay())
            {
                _toiletState = State.Locked;
                return new ToiletDoorResult( "You must pay", Color.Red);
            }
            _toiletState = State.Unlocked;
            return new ToiletDoorResult( "Door opened", Color.Green);

        }

        public ToiletDoorResult OpenDoor()
        {
            if (_toiletState == State.Unlocked)
            {
                _toiletState = State.Occupied;
                return new ToiletDoorResult( "Toilet is occupied", Color.Orange);
            }

            if (_toiletState == State.Occupied)
            {
                return new ToiletDoorResult("Toilet is still occupied!", Color.Orange);
            }

            return new ToiletDoorResult( "Door locked", Color.Red);
        }

        public ToiletDoorResult LeaveToilet()
        {
            _toiletState = State.Locked;

            return new ToiletDoorResult( "Door locked", Color.Red);
        }
    }
}
