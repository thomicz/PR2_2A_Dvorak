namespace _00_opakovani_07_sude_nebo_liche
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int number;

            do
            {
                Console.WriteLine($"Zadej číslo: ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out number));

            if (number == 0)
            {
                Console.WriteLine($"Číslo {number} není sudé, ani liché.");
            }
            else if (number % 2 == 0)
            {
                Console.WriteLine($"Číslo {number} je sudé.");
            }
            else if (number % 2 == 1)
            {
                Console.WriteLine($"Číslo {number} je liché.");
            }
        }
    }
}
