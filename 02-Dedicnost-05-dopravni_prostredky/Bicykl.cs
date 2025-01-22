namespace _02_Dedicnost_05_dopravni_prostredky
{
    internal class Bicykl : DopravniProstredek
    {
        public Bicykl(double maxRychlost) : base("bicykl", TypPohonu.Manualni, maxRychlost, 1)
        {
        }

        public override void Natankuj()
        {
            Console.WriteLine("jdu na svačinu");
        }
    }
}
