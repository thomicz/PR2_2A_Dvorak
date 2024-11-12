namespace _02_Dedicnost_03_bankovni_ucty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Základní účet
            Ucet ucet1 = new Ucet();
            ucet1.Uloz(120);
            Console.WriteLine($"Na účtu je {ucet1.Stav}Kč");
            ucet1.Vyber(80);
            Console.WriteLine($"Na účtu je {ucet1.Stav}Kč");

            //Spořící účet
            SporiciUcet sporici1 = new SporiciUcet();
            sporici1.Uloz(120);
            Console.WriteLine($"Na účtu je {sporici1.Stav}Kč");
            sporici1.Urokuj();
            Console.WriteLine($"Na účtu je {sporici1.Stav}Kč");

            //Účet s poplatkem
            UcetSPoplatkem poplatek1 = new UcetSPoplatkem(10, 15);
            poplatek1.Uloz(120);
            Console.WriteLine($"Na účtu je {poplatek1.Stav}Kč");
            poplatek1.Vyber(40);
            Console.WriteLine($"Na účtu je {poplatek1.Stav}Kč");


        }
    }
}
