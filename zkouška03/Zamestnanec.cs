using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zkouška03
{
    abstract class Zamestnanec : Clovek
    {
        public int Mzda { get; protected set; }
        public string Povolani { get; protected set; }

        public Zamestnanec(string jmeno, Pohlavi pohlavi, int mzda, string povolani) : base(jmeno, pohlavi)
        {
            Mzda = mzda;
            Povolani = povolani;
        }

        public abstract string Pracuj();

    }

}
