namespace _00_opakovani_18_analyza_pole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kladne = 0;
            int zaporne = 0;
            int nulove = 0;

            Random random = new Random();

            int[] pole = new int[10];

            for (int i = 0; i < pole.Length; i++)
            {
                pole[i] = random.Next(-10, 11);
            }

            Console.Write($"Pole: ");

            for (int i = 0; i < pole.Length; i++)
            {
                Console.Write($"{pole[i]} ");

                if (pole[i] == 0)
                {
                    nulove++;
                }
                else if (pole[i] > 0)
                {
                    kladne++;
                }
                else
                {
                    zaporne++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Kladný: {kladne}, Nulový: {nulove}, Záporný: {zaporne}");
        }
    }
}
