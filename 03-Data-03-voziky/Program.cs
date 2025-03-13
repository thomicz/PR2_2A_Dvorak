namespace _03_Data_03_voziky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(123456); //Radnom generátor čísel se seedem 123456

            Stack<int> zakaznici = new Stack<int>();

            Obchod obchod = new Obchod(rnd.Next(500, 1010), 360, 1080, 50, 10, 30);

            int aktualniCas = obchod.ZacatekProvozu;

            while (aktualniCas <= obchod.KonecProvozu)
            {
                Cyklus(obchod, aktualniCas);
                aktualniCas++;
            }

            Vypsat(obchod);
        }
        static void Cyklus(Obchod obchod, int aktualniCas)
        {
            Random rnd = new Random(123456);

            int prichoziZakaznici = rnd.Next(1, obchod.MaxPocetZakaznikuZaMinutu);

            for (int i = 0; i < prichoziZakaznici; i++)
            {
                obchod.voziky.Peek().Pouzit(rnd.Next(obchod.MinDobaNakupu, obchod.MaxDobaNakupu + 1), aktualniCas);
                obchod.vozikyPouzite.Add(obchod.voziky.Pop());

                for (int j = 0; j < obchod.vozikyPouzite.Count; j++)
                {
                    if (obchod.vozikyPouzite[j].DobaVraceni == aktualniCas)
                    {
                        obchod.vozikyPouzite[j].Vratit();
                        obchod.voziky.Push(obchod.vozikyPouzite[j]);
                        obchod.vozikyPouzite.RemoveAt(j);

                    }
                }
            }
        }


        static void Vypsat(Obchod obchod)
        {
            for (int i = 0; i < obchod.vozikyPouzite.Count; i++)
            {
                Console.WriteLine($" ID{obchod.vozikyPouzite[i].ID}: {obchod.vozikyPouzite[i].DobaProvozu} minut");

            }
        }

    }
}
