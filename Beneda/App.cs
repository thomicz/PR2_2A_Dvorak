namespace obchodni_sit;

public class App
{
    public IPage SelectPage;
    public string OpenFile;
    public Salesman Root;
    public string ListPath = "../../../list/";

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            SelectPage.Display();
            
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow) SelectPage.Down();
            else if (key.Key == ConsoleKey.DownArrow) SelectPage.Up();
            else if (key.Key == ConsoleKey.Spacebar)
            {
                SelectPage.PressSelect();
            }

        }
    }
    
    public void ChangeOpenFile(string openFile)
    {
        OpenFile = openFile;
    }
    
    public string GetFileName()
    {
        ConsoleKeyInfo key;
        Console.Clear();
        Console.WriteLine("ZADEJTE NAZEV SOUBORU ZE SLOZKY list:");
        Console.Write(OpenFile);
        do
        {
            while ((key = Console.ReadKey()).Key != ConsoleKey.Enter || OpenFile.Length == 0)
            {
                if (key.Key == ConsoleKey.Backspace )
                {
                    if (OpenFile.Length != 0)
                    {
                        OpenFile = OpenFile.Substring(0, OpenFile.Length - 1);
                    }
                }
                else
                {
                    if (key.Key != ConsoleKey.Enter)
                    {
                        OpenFile += key.KeyChar;
                    }
                }
                Console.Clear();
                Console.WriteLine("ZADEJTE NAZEV SOUBORU ZE SLOZKY list:");
                Console.Write(OpenFile);
            }

            if (!File.Exists(ListPath + OpenFile) || OpenFile.Substring(OpenFile.Length - 4) != ".txt")
            {
                Console.Clear();
                Console.WriteLine("ZADEJTE NAZEV SOUBORU ZE SLOZKY list:");
                Console.WriteLine("File not found");
                Console.WriteLine("Chcete vytvorit (y/n)");
                if (Console.ReadKey().KeyChar == 'y')
                {
                    File.WriteAllText(ListPath + OpenFile, "\n");
                    break;
                }
                Console.Clear();
                Console.WriteLine("ZADEJTE NAZEV SOUBORU ZE SLOZKY list:");
                Console.Write(OpenFile);
            }
            else
            {
                break;
            }
         }while(true);

        
        

        return OpenFile;
    }
}