namespace _02_Dedicnost_05_dopravni_prostredky
{
    abstract class Automobil : DopravniProstredek
    {
        public Automobil(TypPohonu pohon, double maxRychlost, int pocetMist) : base("automobil", pohon, maxRychlost, pocetMist) { }
        
        
    }
}
