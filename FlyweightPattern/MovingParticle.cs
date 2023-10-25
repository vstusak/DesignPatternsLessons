using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    public class MovingParticle
    {
        public Point Coords { get; set; }
        public int Vector { get; set; }
        public int Speed { get; set; }
        public Particle Particle { get; }

        public MovingParticle(Point coords, int vector, int speed, Particle particle)
        {
            Coords = coords;
            Vector= vector;
            Speed = speed;
            Particle = particle;

        }

        public override string ToString()
        {
            return $"{Coords.X}, {Coords.Y}";
        }
    }

}
