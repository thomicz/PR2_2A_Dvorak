namespace _00_opakovani_15_je_trojuhlenik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double a;
            double b;
            double c;

            do
            {
                Console.WriteLine($"Zadej stranu a: ");
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out a));

            do
            {
                Console.WriteLine($"Zadej stranu b: ");
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out b));

            do
            {
                Console.WriteLine($"Zadej stranu c: ");
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out c));

            if (a + b > c && a + c > b && b + c > a)
            {
                Console.WriteLine($"Trojůhelník lze složit.");
            }
            else
            {
                Console.WriteLine($"Trojúhelník nelze složit.");
            }
        }
    }
}
