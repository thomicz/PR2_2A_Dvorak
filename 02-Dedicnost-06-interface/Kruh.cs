namespace _02_Dedicnost_06_interface
{
    internal class Kruh : IUtvar
    {
        public string Nazev => "kruh";
        public double Polomer { get; init; }

        public Kruh(double polomer)
        {
            Polomer = polomer;
        }

        public double GetObsah() => Math.PI * Polomer * Polomer;
        public double GetObvod() => 2 * Math.PI * Polomer;

        public override string ToString() => $"Kruh o poloměru {Polomer}";

    }
}
