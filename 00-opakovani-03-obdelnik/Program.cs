namespace _00_opakovani_03_obdelnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            string input;

            do
            {
                Console.WriteLine($"Zadej první stranu obdélníka: ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out a));

            do
            {
                Console.WriteLine($"Zadej druhou stranu obdélníka: ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out b));

            Console.WriteLine($"Obvod obdélníka je {2 * (a + b)}cm a obsah obdélníka je {a * b}cm^2.");
        }
    }
}
