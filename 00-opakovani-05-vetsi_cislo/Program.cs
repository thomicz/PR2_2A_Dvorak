namespace _00_opakovani_05_vetsi_cislo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int number1;
            int number2;


            do
            {
                Console.WriteLine($"Zadej první číslo: ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out number1));

            do
            {
                Console.WriteLine($"Zadej druhé číslo: ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out number2));

            if (number1 > number2)
            {
                Console.WriteLine($"Číslo {number1} je větší než {number2}.");
            }
            else if (number1 < number2)
            {
                Console.WriteLine($"Číslo {number1} je menší než {number2}.");
            }
            else
            {
                Console.WriteLine($"Číslo {number1} je rovno číslu {number2}.");
            }
        }
    }
}
