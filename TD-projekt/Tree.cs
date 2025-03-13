using _03_Data_03_Obchodnici;

namespace TD_projekt
{
    internal class Tree
    {
        public Salesman Root { get; set; } = Salesman.DeserializeTree(File.ReadAllText("smalltree.json"));
        public Salesman Node { get; set; } = Salesman.DeserializeTree(File.ReadAllText("smalltree.json"));
        public Stack<Salesman>? Stack { get; set; } = new Stack<Salesman>();
        public List<Salesman>? List { get; set; } = new List<Salesman>();
        public string Path { get; set; } = "";
    }
}
