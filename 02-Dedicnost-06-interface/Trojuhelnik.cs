namespace _02_Dedicnost_06_interface
{
    internal class Trojuhelnik : IUtvar
    {
        public string Nazev => "trojúhelník";
        public double A { get; init; }
        public double B { get; init; }
        public double C { get; init; }


        public Trojuhelnik(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double GetObsah()
        {
            double s = GetObvod() / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
        public double GetObvod() => A + B + C;
        public override string ToString() => $"Trojúhleník o stranách {A}, {B}, {C}";

    }
}
