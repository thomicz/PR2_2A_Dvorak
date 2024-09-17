namespace _01_OOP_01_role
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Role role = new Role("červená", 12.3);

            Console.WriteLine($"Délka je {role.Delka}m.");
            Console.WriteLine($"Barva je {role.Barva}.");
        }
    }
}
