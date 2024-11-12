namespace _02_Dedicnost_03_bankovni_ucty
{
    internal class UcetSPoplatkem : Ucet
    {
        public UcetSPoplatkem(double _poplatekZaVyber, double _poplatekZaVklad)
        {
            if (_poplatekZaVklad >= 0)
            {
                PoplatekZaVklad = _poplatekZaVklad;
            }
            if (_poplatekZaVyber >= 0)
            {
                PoplatekZaVyber = _poplatekZaVyber;
            }
        }
        public double PoplatekZaVyber { get; private set; }
        public double PoplatekZaVklad { get; private set; }

        public void Vyber(double castka)
        {
            if ((Stav - PoplatekZaVyber) - castka >= 0)
            {
                Stav -= PoplatekZaVyber;
                Stav -= castka;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public void Uloz(double castka)
        {
            if (castka + Stav >= PoplatekZaVklad)
            {
                Stav -= PoplatekZaVklad;
                Stav += castka;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
