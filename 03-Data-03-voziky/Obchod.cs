namespace _03_Data_03_voziky
{
    internal class Obchod
    {
        Random rnd = new Random(123456);
        public Obchod(int pocetVoziku, int zacatekProvozu, int konecProvozu, int maxPocetZakaznikuZaMinutu, int minDobaNakupu, int maxDobaNakupu)
        {
            PocetVoziku = pocetVoziku;
            ZacatekProvozu = zacatekProvozu;
            KonecProvozu = konecProvozu;
            MaxPocetZakaznikuZaMinutu = maxPocetZakaznikuZaMinutu;
            MinDobaNakupu = minDobaNakupu;
            MaxDobaNakupu = maxDobaNakupu;
        }
        public int PocetVoziku { get; set; }
        public int ZacatekProvozu { get; private set; }
        public int KonecProvozu { get; private set; }
        public int MaxPocetZakaznikuZaMinutu { get; private set; }
        public int MinDobaNakupu { get; private set; }
        public int MaxDobaNakupu { get; private set; }

        public Stack<Vozik> voziky = VytvoritVoziky(500);
        public List<Vozik> vozikyPouzite = new List<Vozik>();

        public static Stack<Vozik> VytvoritVoziky(int pocetVoziku)
        {
            Stack<Vozik> voziky = new Stack<Vozik>();

            for (int i = 0; i < pocetVoziku; i++)
            {
                voziky.Push(new Vozik(i));
            }

            return voziky;
        }
    }
}
