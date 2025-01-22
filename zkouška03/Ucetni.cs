using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zkouška03
{
     internal class Ucetni : Zamestnanec
    {
        public Ucetni(string jmeno, Pohlavi pohlavi, int mzda) : base(jmeno, pohlavi, mzda, "jj") { }

        public override string Pracuj()
        {
            return "Kontroluji faktury";
        }
    }
}
