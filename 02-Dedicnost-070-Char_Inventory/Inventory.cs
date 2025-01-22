using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_OOP2_070_Char_Inventory
{
    internal class Inventory
    {
        private List<Item> _items = new List<Item>();

        public int TotalWeight => _items.Sum(x => x.Weight);
        //public int TotalWeight
        //{
        //    get
        //    {
        //        int weight = 0;
        //        foreach (Item i in _items)
        //        {
        //            weight += i.Weight;
        //        }
        //        return weight;
        //    }
        //}

        public void Take(Item item)
        {
            if (_items.Contains(item))
                return;

            _items.Add(item);
        }

        public void Drop(Item item)
        {
            _items.Remove(item);
        }

        public bool Contains(Item item) => _items.Contains(item);
    }
}
