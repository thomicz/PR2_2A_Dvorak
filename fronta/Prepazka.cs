namespace fronta
{
    internal class Prepazka
    {
        public Prepazka(string id)
        {
            ID = id;
            KdyBudeVolno = 0;
        }

        public string ID { get; private set; }
        public int KdyBudeVolno { get; private set; }

        public void Vyrid(Clovek clovek)
        {
            KdyBudeVolno += clovek.Trvani;
        }
    }
}
