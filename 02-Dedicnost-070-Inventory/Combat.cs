namespace _02_Dedicnost_070_Inventory
{
    internal class Combat
    {
        public Character Fighter1;
        public Character Fighter2;

        public void Fight()
        {
            while (Fighter1.IsAlive && Fighter2.IsAlive)
            {
                Round();
            }
            //dokud oba žijí
            //odhrajte kolo
        }
        public void Round()
        {
            Character first = null, second = null;

            while (first is null)
            {
                int roll1 = Fighter1.IntiativeRoll();
                int roll2 = Fighter2.IntiativeRoll();

                if (roll1 > roll2)
                {
                    first = Fighter1;
                    second = Fighter2;
                }
                else if (roll1 < roll2)
                {
                    first = Fighter2;
                    second = Fighter1;
                }
            }
            //zjistí iniciativu
            //jeden utoci, druhy se brani
            //pak naopak
            Exchange(first, second);

            if (second.IsAlive)
            {
                Exchange(second, first);
            }
        }
        public void Exchange(Character attacker, Character defender)
        {
            (int attack, int damage) = attacker.AttactRoll();
            int defense = defender.DefenseRoll();

            if (defense >= attack)
            {
                //ubranil se
            }
            else
            {
                int wound = attack - defense + damage;
                if (wound < 0)
                {
                    wound = 0;
                }

                defender.DecreaseHealth(wound);
            }
        }
    }
}
