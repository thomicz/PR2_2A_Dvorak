namespace _00_opakovani_27_vypis_podle_znaku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] znaky = new char[,]
            {
    { 'a', 'b', 'c', 'd', 'e', 'f' },
    { 'g', 'h', 'i', 'j', 'k', 'l' },
    { 'm', 'n', 'o', 'p', 'q', 'r' },
    { 't', 'u', 'v', 'w', 'x', 'y' }
            };

            char input;
            do
            {
                Console.WriteLine($"Napiš, zda chceš vypsat řádek (r) nebo sloupec (s)");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            while (input != 'r' && input != 's');

            string tmp;
            if (input == 'r')
            {
                int radek;
                do
                {
                    Console.WriteLine($"Napiš číslo řádku: (1 - {znaky.GetLength(0)})");
                    tmp = Console.ReadLine();
                }
                while (!int.TryParse(tmp, out radek) || radek > znaky.GetLength(0) || radek < 1);

                Console.WriteLine();

                for (int i = 0; i < znaky.GetLength(1); i++)
                {
                    Console.Write(znaky[radek - 1, i]);
                }
            }
            else
            {
                int sloupec;
                do
                {
                    Console.WriteLine($"Napiš číslo sloupce: (1 - {znaky.GetLength(1)})");
                    tmp = Console.ReadLine();
                }
                while (!int.TryParse(tmp, out sloupec) || sloupec > znaky.GetLength(1) || sloupec < 1);

                Console.WriteLine();

                for (int i = 0; i < znaky.GetLength(0); i++)
                {
                    Console.Write(znaky[i, sloupec - 1]);
                }
            }
        }
    }
}
