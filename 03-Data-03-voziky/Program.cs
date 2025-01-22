namespace _03_Data_03_voziky
{
    internal class Program
    {
        Random rnd = new Random(123456);
        void Main(string[] args)
        {
        Stack<int> zakaznici = new Stack<int>();

        Obchod obchod = new Obchod();
            int aktualniCas = obchod.ZacatekProvozu;

            while(aktualniCas <= obchod.KonecProvozu)
            {
                Cyklus(obchod, zakaznici);
                aktualniCas++;
            }
           
        }
        void Cyklus(Obchod obchod, Stack<int> zakaznici)
        {
            int prichoziZakaznici = rnd.Next(1, obchod.MaxPocetZakaznikuZaMinutu);

            for (int i = 0; i < prichoziZakaznici; i++)
            {
                obchod.PocetVoziku--;
                rnd.Next(obchod.MinDobaNakupu, obchod.MinDobaNakupu + 1);
                obchod.voziky.Pop();
                

            }
        }
    }

    class Obchod
    {
        public Stack<int> voziky = new Stack<int>();
        Random rnd = new Random(123456);
        public int PocetVoziku { get; set; }
        public int ZacatekProvozu { get; set; }
        public int KonecProvozu { get; set; }
        public int MaxPocetZakaznikuZaMinutu { get; set; }
        public int MinDobaNakupu { get; set; }
        public int MaxDobaNakupu { get; set; }

        public void Main()
        {
            PocetVoziku = rnd.Next(1, 101);
            MaxPocetZakaznikuZaMinutu = rnd.Next(1, 51);
            ZacatekProvozu = 360;
            KonecProvozu = 1080;
            MinDobaNakupu = 5;
            MaxDobaNakupu = 30;

            for (int i = 0; i < PocetVoziku - 1; i++)
            {
                voziky.Push(i);
            }
        }
    }
}
