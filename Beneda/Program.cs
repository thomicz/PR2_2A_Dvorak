namespace obchodni_sit;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        string filename = "../../../largetree.json";
        Salesman boss = Salesman.DeserializeTree(File.ReadAllText(filename));
        
        App app = new App();
        
        
        
        PageOne pageOne = new PageOne(boss, app);
        app.SelectPage = pageOne;
        app.Root = boss;
        
        app.Run();
    }
    static void DisplaySalesmenTree(Salesman node, string indent = "")
    {
        Console.WriteLine($"{indent}{node.Name} {node.Surname} - Sales: {node.Sales}");

        foreach (var subordinate in node.Subordinates)
        {
            DisplaySalesmenTree(subordinate, indent + "    ");
        }
    }
    
    
}

