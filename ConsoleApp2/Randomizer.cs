using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Randomizer
    {
        int[] _data;
        int _index;
        Random _random = new Random();

        public int Remaining => _data.Length - _index;

        public Randomizer(int[] data)
        {
            //_data = (int[])data.Clone();
            _data = [.. data]; //kopie dat
            Shuffle();
        }

        private void Shuffle()
        {
            _index = 0;

            //zamíchej
            //_data = _data.OrderBy(x => random.NextDouble()).ToArray();

            for (int i = _data.Length - 1; i > 0; i--)
            {
                int rndIndex = _random.Next(i + 1);
                int tmp = _data[i];
                _data[i] = _data[rndIndex];
                _data[rndIndex] = tmp;
            }
        }

        public int Next()
        {
            if (Remaining > 0)
                return _data[_index++];
            else
                throw new InvalidOperationException("No data remaining in randomizer");
        }
    }
}
