namespace zkouska02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter stepcounter = new StepCounter(2);

            for (int i = 0; i < 10; i++)
            {
                stepcounter.Next();
                Console.WriteLine(stepcounter.Count);
            }

            stepcounter.Reset();

            Console.WriteLine(stepcounter.Count);

            DownCounter downcounter = new DownCounter(3, 100);

            while (!downcounter.IsFinished)
            {
                downcounter.Next();
                Console.WriteLine(downcounter.Count);

            }
            downcounter.Reset();
            Console.WriteLine(downcounter.Count);


        }
    }
}
