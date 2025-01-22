namespace _02_Dedicnost_04_zamestnanci
{
    internal class Dobrovolnik : Zamesnanec
    {
        public Dobrovolnik(string jmeno, string prijmeni) : base(jmeno, prijmeni)
        {
        }

        public override int Mzda()
        {
            return 0;
        }

        
    }
}
