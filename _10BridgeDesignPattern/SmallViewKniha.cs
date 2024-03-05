using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_BridgePattern
{
    internal class SmallViewKniha
    {
        private readonly Kniha _kniha;

        public SmallViewKniha(Kniha kniha)
        {
            _kniha = kniha;
        }

        public void Write()
        {
            Console.WriteLine(_kniha.Nazev);
            Console.WriteLine(_kniha.Nakladatelstvi);
            Console.WriteLine(_kniha.Autor);
            Console.WriteLine(_kniha.Uryvek);
        }
    }
}
