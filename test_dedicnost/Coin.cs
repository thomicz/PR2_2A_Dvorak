namespace test_dedicnost
{
    internal class Coin : Item, IStorable
    {
        public int Weight { get; set; } = 1;
        public int Value { get; set; }

        public Coin(string name, int value) : base("Coin")
        {
            Name = name;
            Value = value;
        }
    }
}
