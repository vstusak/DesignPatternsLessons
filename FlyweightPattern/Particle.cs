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
        
        public Color Color { get; set; }
        public byte[] Sprite { get; set; }

        public Particle(Color color)
        {
            Sprite = new byte[1048 * 1048];
            Color = color;
        }

        
    }

}
