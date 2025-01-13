namespace test_dedicnost
{
    internal class Weapon : Item, IStorable, IUsable
    {
        public int RandomGeneratorCisel()
        {
            Random random = new Random();
            return random.Next(0, MaxDamage - 1);
        }
        public int Weight { get; set; }
        public int MinLevel { get; set; }

        public int MaxDamage { get; set; }
        public Weapon(string name, int minlevel, int weight, int maxdamage) : base (name)
        {
            Name = name;
            Weight = weight;
            MinLevel = minlevel;
            MaxDamage = maxdamage;
        }

        public string Use()
        {
            return $"Attacking with my {Name}, damage is {RandomGeneratorCisel()}";
        }
    }
}
