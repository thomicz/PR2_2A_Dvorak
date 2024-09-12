namespace _00_opakovani_16_je_prvocislo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            double number;
            bool jePrvocislo = true;

            do
            {
                Console.WriteLine($"Zadej číslo: ");
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out number));

            for (int i = 2; i <= number / 2; i ++)
            {
                if (!JeDesetinne(number / i))
                {
                    jePrvocislo = false;
                    break;
                }
            }

            if (jePrvocislo)
            {
                Console.WriteLine($"Číslo {number} je prvočíslo.");
            }
            else
            {
                Console.WriteLine($"Číslo {number} není prvočíslo.");
            }
        }
        public static bool JeDesetinne (double input)
        {
            if(input == Math.Round(input, 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
