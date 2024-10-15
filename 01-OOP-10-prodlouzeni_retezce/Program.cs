using System.Diagnostics;
using System.Text;

namespace _01_OOP_10_prodlouzeni_retezce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            StringBuilder builder = new StringBuilder();

            int count = 10000000;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            //Nedělat toto:
            //for(int i = 0; i < count; i++)
            //{
            //    str += 'A';
            //}

            //Dělat toto:
            for (int i = 0; i < count; i++)
            {
                builder.Append(str);
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(stopwatch.ElapsedTicks);
        }
    }
}
