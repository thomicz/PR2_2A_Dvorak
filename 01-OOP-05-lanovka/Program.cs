namespace _01_OOP_05_lanovka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lanovka lanovka = new Lanovka(8, 850);

            Clovek franta = new Clovek();
            franta.Jmeno = "Franta";
            franta.Hmotnost = 60;

            Clovek tomas = new Clovek();
            tomas.Jmeno = "Tomas";
            tomas.Hmotnost = 65;

            Clovek honza = new Clovek();
            honza.Jmeno = "Honza";
            honza.Hmotnost = 80;


            lanovka.Nastup(franta);
            lanovka.Jed();
            lanovka.Nastup(honza);

            try
            {
                lanovka.Jed();
                lanovka.Jed();
            }
            catch
            {
                Console.WriteLine($"V poslední kabince je stále člověk!");
            }

            lanovka.Nastup(tomas);
            
            try
            {
                lanovka.Jed();
                lanovka.Jed();
            }
            catch
            {
                Console.WriteLine($"V poslední kabince je stále člověk!");
            }
           
                lanovka.Vystup();

            for (int i = 0; i < lanovka.lanovka.Length; i++)
            {
                if (lanovka.lanovka[i] == null)
                {
                    Console.WriteLine($"Null");
                }
                else
                {
                    Console.WriteLine(i + 1 + ". " + lanovka.lanovka[i].Jmeno + " / " + lanovka.lanovka[i].Hmotnost);

                }
            }




        }
    }
}
