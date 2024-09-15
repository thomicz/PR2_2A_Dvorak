namespace _00_opakovani_23_metody_koule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double polomer = 4.3;

            Console.WriteLine($"Povrch koule je {Povrch(polomer)}cm^2 a objem je {Objem(polomer)}cm^3.");
        }
        public static double Povrch(double polomer)
        {
            return 4 * Math.PI * Math.Pow(polomer, 2);
        }

        public static double Objem(double polomer)
        {
            return 0.75 * Math.PI * Math.Pow(polomer, 3);
        }
    }
}
