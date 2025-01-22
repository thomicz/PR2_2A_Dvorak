using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace zkouška03
{
    internal class Clovek
    {
        public string Jmeno { get; protected set; }
        public Pohlavi Pohlavi { get; protected set; }

        public Clovek(string jmeno, Pohlavi pohlavi) 
        {
            Jmeno = jmeno;
            Pohlavi = pohlavi;
        }

        public override string ToString()
        {
            return $"Jmenuje se {Jmeno} a jsem {Pohlavi}";
        }
    }
}
