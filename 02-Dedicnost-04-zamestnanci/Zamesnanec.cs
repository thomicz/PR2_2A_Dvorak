using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Dedicnost_04_zamestnanci
{
    internal abstract class Zamesnanec
    {
        //Init znamená, že ji lze nastavit v konstruktoru, ale už ji nelze dále upravovat
        public string Jmeno { get; private init; }
        public string Prijmeni { get; private init; }

        protected Zamesnanec(string jmeno, string prijmeni)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
        }

        public override int Cislo(int mzda)
        {

        }
        

    }
}
