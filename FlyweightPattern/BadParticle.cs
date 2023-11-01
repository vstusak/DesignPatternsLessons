using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    public class BadParticle : ParticleParent
    {
        public Point Coords { get; set; }
        public int Vector { get; set; }
        public int Speed { get; set; }
        public Color Color { get; set; }
        public BadParticle(Point coords, int vector, int speed)
        {
            Coords = coords;
            Vector = vector;
            Speed = speed;
            Color = Color.AliceBlue;
            Sprite = new byte[2048 * 2048];
        }
    }
}
