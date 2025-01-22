namespace _02_Dedicnost_05_dopravni_prostredky
{
    internal sealed class Motocykl : DopravniProstredek
    {
        public Motocykl(double maxRychlost) : base("Motorka", TypPohonu.SpalovaciMotor, maxRychlost, 1) { }

        public override void Natankuj()
        {
            Console.WriteLine("Plním nádrž benzínem");
        }
    }
}
