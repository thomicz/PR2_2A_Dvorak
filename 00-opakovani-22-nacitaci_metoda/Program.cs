namespace _00_opakovani_22_nacitaci_metoda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cislo = Nacitani();
            Console.WriteLine(cislo);
        }
        static double Nacitani()
        {
            string input;
            double number;

            do
            {
                Console.WriteLine($"Zadej desetinné číslo: ");
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out number));

            return number;
        }
    }
}
