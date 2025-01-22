namespace _02_Dedicnost_06_interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUtvar[] utvary = new IUtvar[4];
            utvary[0] = new Ctverec(3);
            utvary[1] = new Kruh(3);
            utvary[2] = new Trojuhelnik(3, 4, 5);
            utvary[3] = new Ctverec(1);


            double obvodTotal = 0;
            double obsahTotal = 0;

            foreach (IUtvar utvar in utvary)
            {
                Console.WriteLine(utvar);
                obsahTotal += utvar.GetObsah();
                obvodTotal += utvar.GetObvod();

                if (utvar.Nazev == "čtverec")
                {

                }
            }

            Dictionary<string, int> pocty = new Dictionary<string, int>();

            foreach (IUtvar utvar in utvary)
            {
                if (pocty.ContainsKey(utvar.Nazev))
                {
                    pocty[utvar.Nazev]++;
                }
                else
                {
                    pocty[utvar.Nazev] = 1;
                }
            }

            foreach (var kvp in pocty)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine($"Celkový obvod je {obvodTotal} a obsah {obsahTotal}.");

            PlechovkaBarvy plechovka = new PlechovkaBarvy(4, 0.1);

            Console.WriteLine(plechovka);

            foreach (IUtvar utvar in utvary)
            {
                bool uspech = plechovka.Obarvi(utvar);
                Console.WriteLine($"{utvar}: {uspech}");
            }
        }
    }
}
