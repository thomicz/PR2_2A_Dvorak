namespace fronta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double pstPrichodu = 1d / 6;
            int minTrvani = 1;
            int maxTrvani = 24;
            int pocitadloLidi = 1;
            int konec = 1440;

            Clovek[] lide = new Clovek[]
            {
                new ("Karel", 3),
                new ("Eva", 7),
                new ("Iva", 1),
                new ("Jeník", 4),
                new ("Karel", 12)

            };

            Queue<Clovek> fronta = new Queue<Clovek>();

            Prepazka[] prepazky = new Prepazka[]
            {
                new Prepazka("A"),
                new Prepazka("B"),
                new Prepazka("C")
            };

            foreach (var osoba in lide)
            {
                fronta.Enqueue(osoba);
            }

            int cas = 0;

            while (cas < konec) //Dokud ve frontě někdo je
            {
                foreach (Prepazka p in prepazky)
                {

                    if (fronta.Count < 1)
                    {
                        break;
                    }

                    if (p.KdyBudeVolno <= cas)
                    {
                        Clovek zakaznik = fronta.Dequeue();
                        p.Vyrid(zakaznik);
                        Console.WriteLine($"{p.ID}: {zakaznik.Jmeno} ({cas} - {cas + p.KdyBudeVolno})");

                    }
                }

                if (rnd.NextDouble() < pstPrichodu)
                {
                    Clovek novy = new Clovek(pocitadloLidi.ToString(), rnd.Next(minTrvani, maxTrvani + 1));
                    pocitadloLidi++;
                    fronta.Enqueue(novy);
                }
                cas++;
            }
        }
    }
}
