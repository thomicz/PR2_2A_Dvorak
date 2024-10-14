namespace _00_Rev_01_posledni_dlouhe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int limit = 4;
            string[] pole = { "dobry", "den", "jak", "se", "dneska", "mate", "?" };
            Console.WriteLine($"{PosledniDlouhe(pole, limit)}");

        }
        public static string PosledniDlouhe(string[] poleRetezcu, int limit)
        {
            for (int i = poleRetezcu.Length - 1; i >= 0; i--)
            {
                if (poleRetezcu[i].Length >= limit)
                {
                    return poleRetezcu[i];
                }
            }
            return "";
        }
    }
}
