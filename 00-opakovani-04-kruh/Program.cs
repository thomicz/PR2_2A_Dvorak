namespace _00_opakovani_04_kruh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int r;

            do
            {
                Console.WriteLine($"Zadej poloměr kruhu: ");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out r));

            Console.WriteLine($"Obvod kruhu je {2 * Math.PI * r}cm a obsah kruhu je {Math.PI * Math.Pow(r, 2)}cm^2.");
        }
    }
}
