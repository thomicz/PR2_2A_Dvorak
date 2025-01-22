namespace _02_Dedicnost_05_dopravni_prostredky
{
    internal abstract class DopravniProstredek
    {
        public string Nazev { get; set; }
        public TypPohonu Pohon { get; set; }
        public double MaxRychlost { get; set; }
        public int PocetMist { get; set; }

        public DopravniProstredek(string nazev, TypPohonu pohon, double maxRychlost, int pocetMist)
        {
            Nazev = nazev;
            Pohon = pohon;
            MaxRychlost = maxRychlost;
            PocetMist = pocetMist;
        }

        public abstract void Natankuj();
       
    
    
    
    }
}
