namespace _02_Dedicnost_06_interface
{
    internal interface IUtvar
    {
        public string Nazev { get; } //V interface je vše automaticky veřejné
        double GetObvod();
        double GetObsah();
    }
}
