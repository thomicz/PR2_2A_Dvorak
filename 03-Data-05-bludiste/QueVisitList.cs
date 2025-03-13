using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_05_bludiste
{
    internal class QueVisitList : IVisitLisr
    {
        Queue<Coords> _queue = [];
        public int Count => _queue.Count;

        public void Add(Coords place)
        {
            _queue.Enqueue(place);
        }

        public Coords NextPlace()
        {
            return _queue.Dequeue();
        }
    }
}
