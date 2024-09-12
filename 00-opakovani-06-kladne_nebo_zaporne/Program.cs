namespace _00_opakovani_06_kladne_nebo_zaporne
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

            if (number > 0)
            {
                Console.WriteLine($"Číslo {number} je kladné.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"Číslo {number} je záporné.");
            }
            else
            {
                Console.WriteLine($"Číslo {number} není kladné, ani záporné.");
            }
        }
    }
}
