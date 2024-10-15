namespace _01_OOP_09_string_ref
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello, World!";
            ModifyStr(text);
            Console.WriteLine(text);
        }

        static void ModifyStr(string str)
        {
            str += "!";
        }

    }
}
