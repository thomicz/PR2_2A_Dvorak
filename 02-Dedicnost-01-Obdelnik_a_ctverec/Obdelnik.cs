namespace _02_Dedicnost_01_Obdelnik_a_ctverec
{
    internal class Obdelnik
    {
        public double StranaA { get; private set; }
        public double StranaB { get; private set; }


        public Obdelnik(double stranaA, double stranaB)
        {
            StranaA = stranaA;
            StranaB = stranaB;
        }

        public double Obsah()
        {
            return StranaA * StranaB;
        }

        public double Obvod()
        {
            return (2 * StranaA + 2 * StranaB);
        }
    }
}
