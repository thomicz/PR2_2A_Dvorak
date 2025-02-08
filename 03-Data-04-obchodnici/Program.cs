namespace _03_Data_04_obchodnici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string filename = "smalltree.json";
            string filename = "largetree.json";
            Salesman boss = Salesman.DeserializeTree(File.ReadAllText(filename));

            //DisplaySalesmenTree(boss);
            //FindByName(boss, "Brown");

            string[] sefove = new string[10];
            ReturnBossSequence(boss, "Brown", sefove);

        }
        static void DisplaySalesmenTree(Salesman node, string indent = "")
        {
            Console.WriteLine($"{indent}{node.Name} {node.Surname} - Sales: {node.Sales}");

            foreach (var subordinate in node.Subordinates)
            {
                DisplaySalesmenTree(subordinate, indent + "    ");
            }
        }

        static void FindByName(Salesman node, string name, string indent = "")
        {
            if (node.Surname == name)
                Console.WriteLine($"{indent}{node.Name} {node.Surname} - Sales: {node.Sales}");

            foreach (var subordinate in node.Subordinates)
            {
                FindByName(subordinate, name, indent + "    ");
            }
        }

        static void ReturnBossSequence(Salesman node, string name, string[] sefove, string indent = "")
        {
            if (node.Surname == name)
                Console.WriteLine($"{indent}{node.Name} {node.Surname} - Sales: {node.Sales}");

            foreach (var subordinate in node.Subordinates)
            {
                ReturnBossSequence(node, name, sefove);
            }
        }
    }
}
