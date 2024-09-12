namespace _00_opakovani_10_soucet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            double number = 0;
            double sum = 0;

            while (true)
            {
                    Console.WriteLine($"Zadej číslo: ");
                    input = Console.ReadLine();

                    if (input == "end")
                    {
                        break;
                    }

                double.TryParse(input, out number);
                sum += number;
            }

            Console.WriteLine($"Součet čísel je {sum}.");
        }

    }
}
