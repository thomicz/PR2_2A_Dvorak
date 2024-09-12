namespace _00_opakovani_01_promenne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;

            int tmp = x;
            x = y;
            y = tmp;

            Console.WriteLine($"Proměnná x má hodnotu {x} a proměnná y má hodnotu {y}.");
        }
    }
}
