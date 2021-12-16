using System.Drawing;

namespace PublicToilet
{
    public class ToiletDoorResult
    {

        public ToiletDoorResult(string v, Color color)
        {
            Message = v;
            Color = color;
        }

        public string Message { get; }
        public Color Color { get; }
    }
}
