namespace _00_opakovani_20_min_avg_max
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sude = 0;
            int liche = 0;
            double min = int.MaxValue;
            double max = int.MinValue;
            double soucet = 0;

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
                if (pole[i] < min)
                {
                    min = pole[i];
                }
                else if (pole[i] > max)
                {
                    max = pole[i];
                }

                soucet += pole[i];

                if (pole[i] % 2 == 0)
                {
                    sude++;
                }
                else
                {
                    liche++;
                }
            }

            Console.WriteLine($"\nNejmenší číslo je {min}, průměrné je {soucet / pole.Length} a nejvyšší je {max}.");
            Console.WriteLine($"V poli je {sude} sudých a {liche} čísel.");
        }
    }
}
