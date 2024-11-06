namespace _02_Dedicnost_01_Obdelnik_a_ctverec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Obdelnik ctverec = new Ctverec(7.3);
            Console.WriteLine(ctverec.Obvod());
            Console.WriteLine(ctverec.Obsah());

        }
    }
}
