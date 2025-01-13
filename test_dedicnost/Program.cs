namespace test_dedicnost
{
    class Program
    {
        public static void Main(string[] args)
        {
            Test();
        }
        public static void Test()
        {
            Spell arrow = new Spell("Magic Arrow", "Vas Ort Flam", 3);
            Spell rip = new Spell("Rest In Peace", "Jux Mani", 5);
            Spell heal = new Spell("Healing", "In Mani Ylem", 1);

            Coin copper = new Coin("copper", 1);
            Coin silver = new Coin("silver", 10);
            Coin gold = new Coin("gold", 100);

            Weapon dagger = new Weapon("Blunt dagger", 1, 3, 3);
            // jmeno, minLevel, váha, maxDamage
            Console.WriteLine(dagger.Use());
            //vypíše zhruba "Attacking with my Blunt dagger, damage is 1" (damage může být 0,1,2,3)
            Weapon axe = new Weapon("Deceiver Axe", 4, 12, 15);
            Weapon sword = new Weapon("Executioner Sword", 1, 25, 10);

            Character hero = new Character(35, 3);
            //nosnost, level
            Console.WriteLine(hero.Store(copper)); //vypíše true
            Console.WriteLine(hero.Store(silver)); //vypíše true
            Console.WriteLine(hero.Store(gold)); //vypíše true
            Console.WriteLine(hero.Store(dagger)); //vypíše true
            Console.WriteLine(hero.Store(axe)); //vypíše true
            Console.WriteLine(hero.Store(sword)); //vypíše false - neunese

            IUsable[] mySurprises = { arrow, rip, heal, dagger, axe, sword };
            // vypíše kouzlení arrow a heal a útok pomocí dagger a sword, zbytek nesplňuje minlevel


        }

    }
}
