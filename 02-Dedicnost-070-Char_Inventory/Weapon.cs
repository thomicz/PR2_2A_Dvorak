using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_070_Char_Inventory
{
    internal class Weapon : Item
    {
        public int Damage { get; private init; }
        public int Attack { get; private init; }
        public bool IsTwoHanded { get; private init; }

        public Weapon(string name, int weight, int damage, int attack, bool isTwoHanded) : base(name, weight)
        {
            Damage = damage;
            Attack = attack;
            IsTwoHanded = isTwoHanded;
        }

    }
}
