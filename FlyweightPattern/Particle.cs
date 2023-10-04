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
    public class Particle
    {
        public Point Coords { get; set; }
        public int Vector { get; set; }
        public int Speed { get; set; }
        public Color Color { get; set; }
        public byte[] Sprite { get; set; }

        public Particle()
        {
            Sprite = new byte[2048 * 2048];
        }

        public override string ToString()
        {
            return $"{Coords.X}, {Coords.Y}";
        }
    }

}
