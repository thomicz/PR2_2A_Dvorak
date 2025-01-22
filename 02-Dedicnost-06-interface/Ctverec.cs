namespace _02_Dedicnost_06_interface
{
    internal class Ctverec : IUtvar
    {
        public string Nazev => "čtverec";
        public double Strana { get; init; }

        public Ctverec(double strana)
        {
            Strana = strana;
        }

        public double GetObsah() => Strana * Strana;
        public double GetObvod() => 4 * Strana;

        public override string ToString() => $"Čtverec o straně {Strana}";
    }
}
