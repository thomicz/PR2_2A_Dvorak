namespace _01_OOP_06_paginator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pole = { "Přemysl", "Nezamysl", "Mnata", "Vojen", "Vnislav", "Křesomysl", "Neklan", "Hostivít" };

            Paginator p = new Paginator(pole, 3);

            Console.WriteLine(p.GetPageItemCount(0));

            string[] test = p.GetPage(0);

            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine(test[i]);
            }

            int demo = p.FindPage("Nezamysl");
            Console.WriteLine(demo);

            int zkouska = p.ItemCount;
            Console.WriteLine(zkouska);

            
        }


    }
}
