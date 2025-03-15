using TD_projekt;

namespace _03_Data_03_Obchodnici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Cursor mainCursor = new Cursor(); //Kurzor pro hlavní interface
            Cursor listCursor = new Cursor(); //Kurzor pro prohlížení seznamu
            Cursor warningCursor = new Cursor(); //Kurzor pro ukládací menu
            Tree t = new Tree();
            Render r = new Render();
            List l = new List();

            r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, mainCursor, t.Path);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (mainCursor.Y > 0)
                    {
                        if (t.Stack.Count == 0 && mainCursor.Y == 3 && t.Path == "")
                        {
                            mainCursor.Y -= 3;
                        }
                        else if ((t.Stack.Count == 0 && mainCursor.Y == 3) || (t.Path == "" && mainCursor.Y == 3))
                        {
                            mainCursor.Y -= 2;
                        }
                        else
                        {
                            mainCursor.Y--;
                        }
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (mainCursor.Y < t.Node.Subordinates.Count + 2)
                    {
                        if (t.Stack.Count == 0 && mainCursor.Y == 0 && t.Path == "")
                        {
                            mainCursor.Y += 3;
                        }
                        else if (t.Stack.Count == 0 && mainCursor.Y == 1)
                        {
                            mainCursor.Y += 2;
                        }
                        else
                        {
                            mainCursor.Y++;
                        }
                    }

                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (mainCursor.X == 0)
                    {
                        mainCursor.X++;
                    }

                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (mainCursor.X == 1)
                    {
                        mainCursor.X--;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, mainCursor, t.Path);
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    l.UnsavedListWarning(t.List, t, mainCursor, r);
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {

                    if (mainCursor.Y == 0 && mainCursor.X == 0) //Přejít nahoru
                    {
                        t.Node = t.Root;
                        t.Stack.Clear();
                    }
                    else if (mainCursor.Y == 0 && mainCursor.X == 1) //Přejít na seznam
                    {
                        Console.Clear();
                        List(listCursor, warningCursor, r, t, l);
                    }
                    else if (mainCursor.Y == 1 && mainCursor.X == 1) //Přidat
                    {
                        if (t.Path != "")
                        {
                            if (!t.List.Contains(t.Node))
                            {
                                l.AddSalesmanToList(t.Node, t.List);
                            }
                            else
                            {
                                l.RemoveSalesmanFromList(t.Node, t.List);
                            }
                        }
                    }
                    else if (mainCursor.Y == 2) //Přejít na nadřízeného
                    {
                        try
                        {
                            t.Node = t.Stack.Pop();
                            r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, mainCursor, t.Path);

                        }
                        catch
                        {
                            r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, mainCursor, t.Path);

                        }
                    }
                    else
                    {
                        t.Stack.Push(t.Node);
                        t.Node = t.Node.Subordinates[mainCursor.Y - 3];
                        mainCursor.FixCursorPosition(t.Node.Subordinates);
                    }

                    Console.Clear();

                }

                r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, mainCursor, t.Path);


            }

            static void List(Cursor listCursor, Cursor warningCursor, Render r, Tree t, List l)
            {
                r.RenderList(t.List, listCursor, t);

                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        if (listCursor.X < 3)
                        {
                            listCursor.X++;
                        }


                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        if (listCursor.X > 0)
                        {
                            listCursor.X--;

                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {

                        if (listCursor.Y == 0 && listCursor.X == 3) //Přejít na prohlížeč
                        {
                            Console.Clear();
                            break;
                        }
                        else if (listCursor.Y == 0 && listCursor.X == 2) //Uložit
                        {
                            l.SaveList(t.List, t);
                        }
                        else if (listCursor.Y == 0 && listCursor.X == 1) //Načíst list
                        {
                            var data = l.LoadList(t.Root, t);
                            t.List = data.Item1;
                            if (t.Path == "")
                            {
                                t.Path = data.Item2;

                            }
                            else
                            {
                                t.Path = data.Item2 + ".txt";
                            }
                        }
                        else if (listCursor.Y == 0 && listCursor.X == 0) //Vytvořit list
                        {
                            l.CreateList(t);

                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        l.UnsavedListWarning(t.List, t, warningCursor, r);
                        Environment.Exit(0);
                    }
                    r.RenderList(t.List, listCursor, t);

                }

            }

            static void DisplaySalesmenTree(Salesman node, string indent = "")
            {
                Console.WriteLine($"{indent}{node.Name} {node.Surname} - Sales: {node.Sales}");

                foreach (var subordinate in node.Subordinates)
                {
                    DisplaySalesmenTree(subordinate, indent + "    ");
                }
            }

            static void FindByNameRecursive(Salesman node, string name)
            {
                if (node.Surname == name)
                    Console.WriteLine($"{node.Name} {node.Surname} - Sales: {node.Sales}");

                foreach (var subordinate in node.Subordinates)
                {
                    FindByNameRecursive(subordinate, name);
                }
            }
            static void FindByNameStack(Salesman root, string name)
            {
                Stack<Salesman> toBeVisited = new Stack<Salesman>();
                toBeVisited.Push(root);

                while (toBeVisited.Count > 0)
                {
                    Salesman node = toBeVisited.Pop();

                    if (node.Surname == name)
                        Console.WriteLine($"{node.Name} {node.Surname} - Sales: {node.Sales}");

                    foreach (var subordinate in node.Subordinates)
                    {
                        toBeVisited.Push(subordinate);
                    }
                }
            }
            static void FindByNameQueue(Salesman root, string name)
            {
                Queue<Salesman> toBeVisited = new Queue<Salesman>();
                toBeVisited.Enqueue(root);

                while (toBeVisited.Count > 0)
                {
                    Salesman node = toBeVisited.Dequeue();

                    if (node.Surname == name)
                        Console.WriteLine($"{node.Name} {node.Surname} - Sales: {node.Sales}");

                    foreach (var subordinate in node.Subordinates)
                    {
                        toBeVisited.Enqueue(subordinate);
                    }
                }
            }


            static int GetTotalSalesStack(Salesman root)
            {
                int total = 0;

                Stack<Salesman> toBeVisited = new Stack<Salesman>();
                toBeVisited.Push(root);

                while (toBeVisited.Count > 0)
                {
                    Salesman node = toBeVisited.Pop();
                    total += node.Sales;

                    foreach (var subordinate in node.Subordinates)
                    {
                        toBeVisited.Push(subordinate);
                    }
                }

                return total;
            }


        }
    }
}
