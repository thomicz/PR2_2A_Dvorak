namespace _00_opakovani_28_nejvic_nul
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            int[,] cisla =
        {
            { 0,  0, 12, 0,  7},
            {13,  0,  5, 0,  1},
            { 0, -1,  0, 4,  5},
            { 1, -1,  0, 0, -5},
        };

            Console.WriteLine(program.NejvicNul(cisla, true));
        }
        public int NejvicNul(int[,] cisla, bool typ)
        {
            int maxNumber = 0;
            int maxIndex = 0;

            if (typ == false)
            {
                int[] pocetNul = new int[cisla.GetLength(0)];
                int nuly = 0;

                for (int i = 0; i < cisla.GetLength(0); i++)
                {
                    for (int j = 0; j < cisla.GetLength(1); j++)
                    {
                        if (cisla[i, j] == 0)
                        {
                            nuly++;
                        }
                    }
                    pocetNul[i] = nuly;
                    nuly = 0;
                }

                for (int i = pocetNul.Length - 1; i >= 0; i--)
                {
                    if (pocetNul[i] >= maxNumber)
                    {
                        maxNumber = pocetNul[i];
                        maxIndex = i;
                    }
                }
                return maxIndex;
            }
            else
            {
                int[] pocetNul = new int[cisla.GetLength(1)];
                int nuly = 0;

                for (int i = 0; i < cisla.GetLength(1); i++)
                {
                    for (int j = 0; j < cisla.GetLength(0); j++)
                    {
                        if (cisla[j, i] == 0)
                        {
                            nuly++;
                        }
                    }
                    pocetNul[i] = nuly;
                    nuly = 0;
                }

                for (int i = pocetNul.Length - 1; i >= 0; i--)
                {
                    if (pocetNul[i] >= maxNumber)
                    {
                        maxNumber = pocetNul[i];
                        maxIndex = i;
                    }
                }
                return maxIndex;
            }

        }

    }
}
