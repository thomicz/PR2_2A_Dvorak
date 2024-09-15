using System.Numerics;

namespace _00_opakovani_19_pruchod_pole_po_indexech
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double soucet = 0;
            double soucin = 1;

            Random random = new Random();

            int[] pole = new int[10];

            for (int i = 0; i < pole.Length; i++)
            {
                pole[i] = random.Next(1, 11);
            }

            Console.Write($"Pole: ");

            for (int i = 0; i < pole.Length; i++)
            {
                Console.Write($"{pole[i]} ");
            }

            for (int i = 0; i < pole.Length; i++)
            {
                if (i % 2 == 0)
                {
                    soucet += pole[i];
                }
                else
                {
                    soucin *= pole[i];
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Součet je {soucet} a součin je {soucin}.");
        }
    }
}
