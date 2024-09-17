namespace _01_OOP_01_role
{
    internal class Role
    {
        public string Barva { get; private set; }
        public double Delka { get; private set; }

        public Role(string barva, double delka)
        {
           Barva = barva;
           Delka = delka;
        }
    }
}
