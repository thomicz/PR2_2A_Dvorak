namespace zkouska01
{
    internal class Obdelnik
    {
        public Obdelnik(double stranaA, double stranaB)
        {
            StranaA = stranaA;
            StranaB = stranaB;
        }

        public double StranaA { get; protected set; }
        public double StranaB { get; protected set; }
        public double Obvod() => 2 * (StranaA + StranaB);
        public double Obsah() => StranaA * StranaB;

        public override string ToString()
        {
            return $"Obdélník o stranách {StranaA} a {StranaB}.";
        }
    }
}
