namespace _06_DB_02_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new MyDBContext();

            var cars = dbContext.Cars.ToList();

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id}: {car.Brand} {car.Model}");
            }

        }
    }
}
