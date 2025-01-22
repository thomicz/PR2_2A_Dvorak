namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cislo = int.Parse(Console.ReadLine());

            Console.WriteLine(JePrvocislo(cislo) ? "ano" : "ne");
        }

        static bool JePrvocislo(int cislo)
        {
            for (int i = 2; i < cislo / 2 + 1; i++)
            {
                if (!JeDesetinne(cislo, i)) return false;
            }
            return true;
        }

        static bool JeDesetinne(double cislo, double i)
        {
            double tmp = cislo / i;

            if (Math.Round(tmp, 0) == tmp) return false;
            else return true;
        }
    }
}
