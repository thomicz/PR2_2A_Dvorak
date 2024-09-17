namespace _01_OOP_02_tachometr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tachometr tachometr = new Tachometr();
            try
            {
                tachometr.Ujed(-15);
                Console.WriteLine($"Ujeto: {tachometr.Stav}km");

            }
            catch
            {
                Console.WriteLine($"Chybný vstup!");
            }

            try
            {
                tachometr.Ujed(110);
                Console.WriteLine($"Ujeto: {tachometr.Stav}km");

            }
            catch
            {
                Console.WriteLine($"Chybný vstup!");
            }

            try
            {
                tachometr.Ujed(25);
                Console.WriteLine($"Ujeto: {tachometr.Stav}km");

            }
            catch
            {
                Console.WriteLine($"Chybný vstup!");
            }
        }
    }
}
