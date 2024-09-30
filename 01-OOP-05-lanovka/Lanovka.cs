namespace _01_OOP_05_lanovka
{
    internal class Lanovka
    {
        private static int _delka;
        private static int _nosnost;
        public Clovek[] lanovka;
        public double Zatizeni { get; private set; } = 0;
        public bool JeVolnoDole { get; private set; }
        public bool JeVolnoNahore { get; private set; }



        public Lanovka(int delka, int nosnost)
        {
            if (delka > 0 && nosnost > 0)
            {
                _delka = delka;
                lanovka =  new Clovek[_delka];
                _nosnost = nosnost;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public bool Nastup(Clovek clovek)
        {
            if (clovek.Hmotnost + Zatizeni <= _nosnost && lanovka[0] == null)
            {
                lanovka[0] = clovek;
                Zatizeni += clovek.Hmotnost;
                return true;
            }
            else
            {
                return false;
            }
        }
        public Clovek Vystup()
        {
            if (lanovka[_delka - 1] == null)
            {
                return null;
            }
            else
            {
                Clovek tmp = lanovka[_delka - 1];
                lanovka[_delka - 1] = null;
                return tmp;
            }
        }
        public Clovek[] Jed()
        {
            if(lanovka[lanovka.Length - 1] != null)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = lanovka.Length - 2; i >= 0; i--)
                {
                    lanovka[i + 1] = lanovka[i];

                }
                lanovka[0] = null;
                return lanovka;

            }
        }
    }
}

