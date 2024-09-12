using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _00_opakovani_09_prumerne_cislo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double howManyTimes;
            double output;
            double sum = 0;

            do
            {
                Console.WriteLine($"Zadej kolik čísel budeš zadávat: ");
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out howManyTimes));

            for (int i = 0; i < howManyTimes; i++)
            {
                do
                {
                    Console.WriteLine($"Zadej {i + 1}. číslo: ");
                    input = Console.ReadLine();
                }
                while (!double.TryParse(input, out output));
                sum += output;
            }
            Console.WriteLine($"Průměr čísel je {sum / howManyTimes}.");
        }
    }
}
