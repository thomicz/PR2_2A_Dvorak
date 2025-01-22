namespace _02_Dedicnost_04_zamestnanci
{
    internal class Firma
    {
        private List<Zamesnanec> _personal = new List<Zamesnanec>();

        public void Zamestnej(Zamesnanec zamesnanec)
        {
            if (!_personal.Contains(zamesnanec))
            {
                _personal.Add(zamesnanec);
            }
        }
        public void Propust(Zamesnanec zamesnanec)
        {
            _personal.Remove(zamesnanec);
        }

        public void Vyplata()
        {
            int total = 0;

            foreach(Zamesnanec zamesnanec in _personal)
            {
                //int mzda = zamesnanec.Mzda();
            }
        }
    }
}
