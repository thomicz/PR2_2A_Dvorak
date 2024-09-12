namespace _00_opakovani_08_je_cele
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double number;

            do
            {
                Console.WriteLine($"Zadej číslo: ");
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out number));

            if (Math.Round(number, 0) == number)
            {
                Console.WriteLine($"Číslo {number} je celé.");
            }
            else
            {
                Console.WriteLine($"Číslo {number} není celé.");
            }
            
        }
    }
}
