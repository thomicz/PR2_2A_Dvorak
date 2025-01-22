using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_070_Char_Inventory
{
    internal class Armor : DefItem
    {
        public Armor(string name, int weight, int defense) : base(name, weight, defense) {}
    }
}
