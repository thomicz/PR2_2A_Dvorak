using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _00_opakovani_17_napln_pole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int size;
            int number;

            do
            {
                Console.WriteLine($"Zadej velikost pole: ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out size));

            int[] pole = new int[size];

            for (int i = 0; i < size; i++)
            {
                do
                {
                    Console.WriteLine($"Zadej {i + 1}. číslo: ");
                    input = Console.ReadLine();
                }
                while (!int.TryParse(input, out number));

                pole[i] = number;
            }

            Console.Clear();
            Console.Write("Zadané hodnoty: ");
            for (int i = 0; i < pole.Length; i++)
            {
                Console.Write($"{pole[i]} ");
            }
        }
    }
}
