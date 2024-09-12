namespace _00_opakovani_11_min_avg_max
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double min = int.MaxValue;
            double max = int.MinValue;
            double sum = 0;
            string input;
            double number;

            for (int i = 0; i < 10;  i++)
            {
                do
                {
                    Console.WriteLine($"Zadej {i + 1}. číslo: ");
                    input = Console.ReadLine();
                }
                while (!double.TryParse(input, out number));

                if (number < min)
                {
                    min = number;
                }
                if (number > max)
                {
                    max = number;
                }
                sum += number;
            }
            Console.WriteLine($"Nejmenší číslo bylo {min}, průměrné {sum / 10} a největší bylo {max}.");
        }
    }
}
