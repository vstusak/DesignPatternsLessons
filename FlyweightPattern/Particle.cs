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
        private static Particle _instance;

        public byte[] Sprite { get; set; }

        private Particle()
        {
            Sprite = new byte[1048 * 1048];
        }

        public static Particle GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Particle();
            }

            return _instance;
        }

    }

}
