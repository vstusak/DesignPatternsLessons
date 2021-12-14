using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet
{
    class PublicToilet
    {
        public PublicToilet()
        {
            ReleaseDoor = false;
        }

        public bool ReleaseDoor { get; set; }
        public void SwipeCard()
        {
            if (PaymentService.Pay())
            {
                ReleaseDoor = true;
            } 
            else
            {
                ReleaseDoor = false;
            }
        }

        public ToiletDoorResult OpenDoor()
        {
            ToiletDoorResult result;
            if (ReleaseDoor)
            {
                ReleaseDoor = false;
                result = new ToiletDoorResult(ReleaseDoor, "Door locked",Color.Red);
                
            }
                        
        }

        
    }
}
