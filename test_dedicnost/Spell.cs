namespace test_dedicnost
{
    internal class Spell : IUsable
    {
        public string Name { get; private set; }
        public string Cast { get; private set; }
        public int MinLevel { get; private set; }
        public Spell(string name, string cast, int minlevel)
        {
            Name = name;
            Cast = cast;
            MinLevel = minlevel;
        }

        public string Use()
        {
            return $"{Name}: {Cast}";
        }
    }
}
