namespace zkouska01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Obdelnik ctverec = new Ctverec(9.4);
            Obdelnik obdelnik = new Obdelnik(7.3, 2.6);

            Console.WriteLine(ctverec.ToString());
            Console.WriteLine(obdelnik.ToString());

            Console.WriteLine($"Obvod obdélníku: {obdelnik.Obvod()}");
            Console.WriteLine($"Obsah ctverce: {ctverec.Obsah()}");
        }
    }
}
