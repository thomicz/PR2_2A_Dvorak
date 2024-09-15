namespace _00_opakovani_26_nacitani_sudych
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int n;
            int number;

            do
            {
                Console.WriteLine($"Zadej kolik čísel budeš zadávat: ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out n) || n <= 0);

            int[] pole = new int[n];


            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.WriteLine($"Zadej celé číslo: ");
                    input = Console.ReadLine();
                }
                while (!int.TryParse(input, out number) || number % 2 == 1);

                pole[i] = number;
            }

            Console.WriteLine();
            for (int i = pole.Length - 1; i >= 0; i--)
            {
                Console.Write($"{pole[i]} ");
            }
        }
    }
}
