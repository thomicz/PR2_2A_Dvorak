namespace _00_Rev_02_prumer_lichych
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string value;
            int cislo;
            double soucetLichychKladnych = 0;
            double pocetLichychKladnych = 0;

            while (true)
            {
                Console.WriteLine($"Zadej číslo: ");
                value = Console.ReadLine();

                if (value == "stop")
                {
                    break;
                }

                int.TryParse(value, out cislo);

                if (cislo > 0 && cislo % 2 == 1)
                {
                    soucetLichychKladnych += cislo;
                    pocetLichychKladnych++;
                }
            }

            if (pocetLichychKladnych == 0)
            {
                Console.WriteLine("Nebylo vloženo žádné kladné liché číslo");
            }
            else
            {
                Console.WriteLine($"Průměr: {soucetLichychKladnych / pocetLichychKladnych}");
            }


        }
    }
}
