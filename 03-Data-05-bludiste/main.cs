using _03_Data_05_bludiste;

class Program
{
    static void Main(string[] args)
    {
        Maze maze = new Maze();
        maze.LoadMaze("maze.txt");
        maze.Solve();
    }
}