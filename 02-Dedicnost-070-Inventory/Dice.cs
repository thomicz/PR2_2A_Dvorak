namespace _02_Dedicnost_070_Inventory
{
    internal class Dice
    {
        private static Random random = null;
        private static Random GetRandom()
        {
            if (random is null)
            {
                random = new Random();
            }
            return random;
        }

        public int Sides;

        public Dice(int sides)
        {
            Sides = sides;
        }

        public int Roll()
        {
            Random rnd = GetRandom();
            return rnd.Next(Sides) + 1;

        }
    }
}
