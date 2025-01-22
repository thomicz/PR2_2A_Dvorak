using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zkouška03
{
    internal class Kuchar : Zamestnanec
    {
        public  Kuchar(string jmeno, Pohlavi pohlavi, int mzda, string hotel) : base(jmeno, pohlavi, mzda, "kuchař") { }

        public override string Pracuj()
        {
            return "Klepu řízky v hotelu …";
        }
    }
}
