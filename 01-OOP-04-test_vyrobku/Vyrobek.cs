namespace _01_OOP_04_test_vyrobku
{
    internal class Vyrobek
    {
        private double rozmer;

        public Vyrobek(double rozmer)
        {
            Rozmer = rozmer;
        }

        public double Rozmer
        {
            get
            {
                return rozmer;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                rozmer = value;
            }
        }
    }
}
