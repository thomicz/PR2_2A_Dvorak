using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_070_Char_Inventory
{
    internal class Character
    {
        public string Name { get; private init; }
        public int Health { get; private set; }
        public int MaxHealth { get; private init; }
        public int MaxWeight { get; private init; }

        public int CarryWeight
        {
            get
            {
                return
                    inventory.TotalWeight
                    + ((LeftHand != null) ? LeftHand.Weight : 0)
                    + RightHand?.Weight ?? 0
                    + Wearing?.Weight ?? 0;
            }
        }


        private Inventory inventory = new Inventory();

        public Item? RightHand = null;
        public Item? LeftHand = null;
        public Armor? Wearing = null;

        public Character(string name, int maxHealth, int maxWeight)
        {
            Name = name;
            MaxHealth = Health = maxHealth;
            MaxWeight = maxWeight;
        }

        public bool Take(Item item)
        {
            if (CanCarry(item))
            {
                inventory.Take(item);
                return true;
            }
            else
            { 
                return false; 
            }
        }
        public void Drop(Item item)
        {
            inventory.Drop(item);
        }

        public bool Equip(Weapon weapon)
        {
            if ((RightHand != null) || (LeftHand != null && weapon.IsTwoHanded))
                return false;

            if (inventory.Contains(weapon))
            {
                inventory.Drop(weapon);
                RightHand = weapon;
                return true;
            }

            if (CanCarry(weapon))
            {
                RightHand = weapon;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Equip(Shield shield)
        {
            if ((LeftHand != null) || (RightHand is Weapon weapon && weapon.IsTwoHanded))
                return false;

            if (inventory.Contains(shield))
            {
                inventory.Drop(shield);
                LeftHand = shield;
                return true;
            }

            if (CanCarry(shield))
            {
                LeftHand = shield;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanCarry(Item item) => item.Weight + CarryWeight <= MaxWeight;
        
    }
}
