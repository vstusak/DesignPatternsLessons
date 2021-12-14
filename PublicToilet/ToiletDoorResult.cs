using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PublicToilet
{
    class ToiletDoorResult
    {       

        public ToiletDoorResult(bool releaseDoor, string v, Color color)
        {
            //this.releaseDoor = releaseDoor;
            Message = v;
            Color = color;
        }

        public string Message { get; }
        public Color Color { get; }
    }
}
