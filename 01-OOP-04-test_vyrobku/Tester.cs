namespace _01_OOP_04_test_vyrobku
{
    internal class Tester
    {
        public double Tolerance { get; private set; }
        public Vyrobek Vzor { get; private set; }

        public Tester(double tolerance, Vyrobek vzor)
        {
            SetTolerance(tolerance);
            SetVzor(vzor);
        }
        public void SetTolerance(double tolerance)
        {
            if (tolerance >= 0 && tolerance <= 100)
            {
                Tolerance = tolerance;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SetVzor(Vyrobek vzor)
        {
            if (vzor != null)
            {
                Vzor = vzor;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public bool Vyhovuje(Vyrobek vyrobek, double tolerance)
        {
            if (vyrobek.Rozmer <= (Vzor.Rozmer / 100) * (100 + tolerance)
                &&(vyrobek.Rozmer >= (Vzor.Rozmer / 100) * (100 - tolerance)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
