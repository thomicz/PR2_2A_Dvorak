namespace fronta
{
    internal class Clovek
    {
        public string Jmeno { get; private set; }
        public int Trvani { get; private set; }

        public Clovek(string jmeno, int trvani)
        {
            Jmeno = jmeno;
            Trvani = trvani;
        }
    }
}
