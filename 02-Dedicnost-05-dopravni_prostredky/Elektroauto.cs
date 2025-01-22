using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Dedicnost_05_dopravni_prostredky
{
    internal sealed class Elektroauto : Automobil
    {
        public Elektroauto(double maxRychlost, int pocetMist) : base(TypPohonu.Elektromotor, maxRychlost, pocetMist)
        {
        }

        public override void Natankuj()
        {
            Console.WriteLine("Připojuji na nabíječku");
        }
    }
}
