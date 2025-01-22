using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_070_Char_Inventory
{
    internal abstract class DefItem : Item
    {
        public int Defense { get; private init; }

        public DefItem(string name, int weight, int defense) : base(name, weight)
        {
            Defense = defense;
        }


    }
}
