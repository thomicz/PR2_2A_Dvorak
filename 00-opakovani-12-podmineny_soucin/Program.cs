namespace _00_opakovani_12_podmineny_soucin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 1;
            string input;
            double number;

            for (int i = 0; i < 10; i++)
            {
                do
                {
                    Console.WriteLine($"Zadej {i + 1}. číslo: ");
                    input = Console.ReadLine();
                }
                while (!double.TryParse(input, out number));

                if (number > 10 && number % 2 == 0)
                {
                    sum *= number;
                }
               
            }
            Console.WriteLine($"Součin je {sum}.");
        }
    }
}
