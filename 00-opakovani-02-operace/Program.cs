namespace _00_opakovani_02_operace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = 10;
            double y = 20;

            double sum = x + y;
            double difference = x - y;
            double product = x * y;
            double quotient = x / y;

            Console.WriteLine($"Součet: {sum}, Rozdíl: {difference}, Součin: {product}, Podíl: {quotient}");

        }
    }
}
