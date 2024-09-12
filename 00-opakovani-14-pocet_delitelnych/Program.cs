namespace _00_opakovani_14_pocet_delitelnych
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double number;
            int delitelne = 0;

            while (true)
            {
                number = 0;
                Console.WriteLine($"Zadej číslo: ");
                input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                double.TryParse(input, out number);

                if ((number % 3 == 0 || number % 4 == 0) && number != 0)
                {
                    delitelne++;
                }

            }
            Console.WriteLine($"Uživatel napsal {delitelne} čísel dělitelných 3 nebo 4.");
        }
    }
}
