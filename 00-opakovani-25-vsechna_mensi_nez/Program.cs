namespace _00_opakovani_25_vsechna_mensi_nez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            double[] pole = { 3, 9, 6, 5, 3 };
            double hodnota = 10;
            bool vysledek = program.JsouVsechnaMensiNez(hodnota, pole);
            Console.WriteLine("Hodnota " + (vysledek ? "je" : "není") + " větší než všechny čísla v poli.");

        }
        public bool JsouVsechnaMensiNez(double hodnota, double[] cisla)
        {
            bool tmp = true;

            for (int i = 0; i < cisla.Length; i++)
            {
                if (hodnota <= cisla[i])
                {
                    tmp = false;
                    return tmp;
                }
            }
            return tmp;
        }
    }
}
