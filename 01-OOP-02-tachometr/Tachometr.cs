namespace _01_OOP_02_tachometr
{
    internal class Tachometr
    {
        private int stav = 0;
        public int Stav
        {
            get => stav;
            private set => stav = value;
        }
        public void Ujed(int value)
        {
            if (value >= 0)
            {
                stav += value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
