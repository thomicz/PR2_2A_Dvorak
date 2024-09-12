namespace _00_opakovani_13_prubezna_statistika
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double number = 0;
            int liche = 0;
            int sude = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Liché: {liche} / Sudé: {sude} \n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Zadej číslo: ");
                input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                double.TryParse(input, out number);

                if (number % 2 == 0)
                {
                    sude++;
                }
                else if (number % 2 == 1)
                {
                    liche++;
                }

                Console.Clear();

            }
        }
    }
}
