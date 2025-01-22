namespace _02_Dedicnost_070_Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character Bob = new Character("Bob", 60, 60);
            Character Cid = new Character("Cid", 50, 60);

            Bob.Equip(new Weapon("Sekera", 20, 3, 2, true));
        }
    }
}
