using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Dedicnost_070_Inventory
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
