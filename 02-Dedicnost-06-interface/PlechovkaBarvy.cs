namespace _02_Dedicnost_06_interface
{
    internal class PlechovkaBarvy
    {
        public double Objem { get; set; }
        public double Vydatnost { get; init; }

        public PlechovkaBarvy(double objem, double vydatnost)
        {
            Objem = objem;
            Vydatnost = vydatnost;
        }

        public override string ToString() => $"V plechovce zbývá barva ještě na {Objem / Vydatnost}cm2";
        public bool Obarvi(IUtvar utvar)
        {
            if (2 * utvar.GetObsah() <= (Objem / Vydatnost))
            {
                Objem -= 2 * utvar.GetObsah();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
