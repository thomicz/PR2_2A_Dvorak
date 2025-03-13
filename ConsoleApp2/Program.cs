namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] nums = [1, 2, 3, 4, 5, 6, 7];
            Randomizer randomizer = new(nums);
            while (randomizer.Remaining > 0)
            {
                Console.WriteLine($"Další číslo je {randomizer.Next()}");
            }
        }
    }
}
