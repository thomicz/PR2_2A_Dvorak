namespace _01_OOP_01_role
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Role role = new Role();

            role.Delka = 4;
            role.Barva = "Modrá";

            Console.WriteLine($"Délka je {role.Delka}m.");
            Console.WriteLine($"Barva je {role.Barva}.");
        }
    }
}
