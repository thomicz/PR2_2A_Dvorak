namespace test_dedicnost
{
    internal class Character
    {
        public int MaxWeight { get; set; }
        public int Level { get; set; }

        public Character(int maxweight, int level)
        {
            MaxWeight = maxweight;
            Level = level;
        }

        List<IStorable> Backpack = new List<IStorable>();

        public bool Store(IStorable thing)
        {
            if (MaxWeight >= thing.Weight)
            {
                Backpack.Add(thing);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UseAll(IUsable[] tools)
        {
            for (int i = 0; i < tools.Length; i++)
            {
                if (Level >= tools[i].MinLevel)
                {
                    tools[i].Use();
                }
            }

            
        }
    }
}
