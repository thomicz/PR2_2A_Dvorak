namespace _02_Dedicnost_01_savec
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Kun kobyla = new Kun();
           kobyla.Dychej();
        }

        /// <summary>
        /// Předal třídě Kun vlastnosti třídy Savec
        /// </summary>
        class Kun : Savec 
        {
            public void Cvalej()
            {
                Console.WriteLine("Hop");
            }
        }
    }
}
