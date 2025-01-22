namespace _02_Dedicnost_05_dopravni_prostredky
{
    internal sealed class Flotila
    {
        List<DopravniProstredek> Uloziste = new List<DopravniProstredek>();
        public int Velikost { get; private set; } = 0;
        public int Kapacita { get; private set; }

        public void PridejVozidlo(DopravniProstredek vozidlo)
        {
            if (Uloziste.Contains(vozidlo))
            {
                throw new Exception();
            }
            else
            {
                Uloziste.Add(vozidlo);
                Velikost++;
            }
        }

        public void OdeberVozidlo(DopravniProstredek vozidlo)
        {

            if (Uloziste.Contains(vozidlo))
            {
                Uloziste.Remove(vozidlo);
                Velikost--;
            }
            else
            {
                throw new Exception();

            }
        }
    }
}
