namespace _00_opakovani_24_faktorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            int cislo = 5;
            Console.WriteLine($"Faktoriál čísla {cislo} je {program.Faktorial(cislo)}.");
        }
        public int Faktorial(int cislo)
        {
            int tmp = 1;

            if (cislo == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i <= cislo; i++)
                {
                    tmp *= i;
                }
                return tmp;
            }
        }
    }
}
