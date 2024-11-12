namespace _02_Dedicnost_03_bankovni_ucty
{
    internal class Ucet
    {
        public double Stav { get; protected set; }

        public void Uloz(double castka)
        {
            if (castka > 0)
            {
                Stav += castka;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Vyber(double castka)
        {
            if (Stav - castka >= 0)
            {
                Stav -= castka;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
