namespace _01_OOP_04_test_vyrobku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vyrobek vzor = new Vyrobek(95.4);
            Tester tester = new Tester(15.3, vzor);

            Vyrobek vyrobek1 = new Vyrobek(98.4);
            Vyrobek vyrobek2 = new Vyrobek(89.7);
            Vyrobek vyrobek3 = new Vyrobek(112.3);
            Vyrobek vyrobek4 = new Vyrobek(80.8039);
            Vyrobek vyrobek5 = new Vyrobek(105.2);

            bool tmp;

            tmp = tester.Vyhovuje(vyrobek1, tester.Tolerance);
            Console.WriteLine("Výrobek o rozměru " + vyrobek1.Rozmer + (tmp ? " je" : " není") + " v míře");

            tmp = tester.Vyhovuje(vyrobek2, tester.Tolerance);
            Console.WriteLine("Výrobek o rozměru " + vyrobek2.Rozmer + (tmp ? " je" : " není") + " v míře");

            tmp = tester.Vyhovuje(vyrobek3, tester.Tolerance);
            Console.WriteLine("Výrobek o rozměru " + vyrobek3.Rozmer + (tmp ? " je" : " není") + " v míře");

            tmp = tester.Vyhovuje(vyrobek4, tester.Tolerance);
            Console.WriteLine("Výrobek o rozměru " + vyrobek4.Rozmer + (tmp ? " je" : " není") + " v míře");

            tmp = tester.Vyhovuje(vyrobek5, tester.Tolerance);
            Console.WriteLine("Výrobek o rozměru " + vyrobek5.Rozmer + (tmp ? " je" : " není") + " v míře");
        }
    }
}
