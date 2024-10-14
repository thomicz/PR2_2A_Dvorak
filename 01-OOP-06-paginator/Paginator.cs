namespace _01_OOP_06_paginator
{
    internal class Paginator(string[] jmena, int limit)
    {
        private string[] _jmena = jmena;
        private int _limit = limit;

        public int ItemCount
        {
            get
            {
                return _jmena.Length;
            }
        }

        public int GetPageItemCount(int n)
        {
            int p = n * _limit;
            int count = 0;

            for (int i = p; i < _limit + p; i++)
            {
                if (i < _jmena.Length)
                {
                    count++;
                }
            }

            return count;
        }

        public string[] GetPage(int n)
        {
            string[] vysledek = new string[this.GetPageItemCount(n)];
            int p = n * _limit;

            for (int i = p; i < vysledek.Length + p; i++)
            {
                vysledek[i - p] = _jmena[i];
            }

            return vysledek;
        }

        public int FindPage(string prvek)
        {
            int p = -1;

            for (int i = 0; i < _jmena.Length; i++)
            {
                if (prvek == _jmena[i])
                {
                    p = i;
                }
            }

            if (p == -1)
            {
                return -1;
            }
            else
            {
                return p / _limit;
            }
        }
    }
}
