using TD_projekt;

namespace _03_Data_03_Obchodnici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Cursor main = new Cursor(); //Kurzor pro hlavní interface
            Cursor list = new Cursor(); //Kurzor pro prohlížení seznamu
            Tree t = new Tree();
            Render r = new Render();
            List l = new List();

            r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, main, t.Path);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (main.Y > 0)
                    {
                        if (t.Stack.Count == 0 && main.Y == 3 && t.Path == "")
                        {
                            main.Y -= 3;
                        }
                        else if ((t.Stack.Count == 0 && main.Y == 3) || (t.Path == "" && main.Y == 3))
                        {
                            main.Y -= 2;
                        }
                        else
                        {
                            main.Y--;
                        }
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (main.Y < t.Node.Subordinates.Count + 2)
                    {
                        if (t.Stack.Count == 0 && main.Y == 0 && t.Path == "")
                        {
                            main.Y += 3;
                        }
                        else if (t.Stack.Count == 0 && main.Y == 1)
                        {
                            main.Y += 2;
                        }
                        else
                        {
                            main.Y++;
                        }
                    }

                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (main.X == 0)
                    {
                        main.X++;
                    }

                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (main.X == 1)
                    {
                        main.X--;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, main, t.Path);
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    l.UnsavedListWarning(t.List, t);
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {

                    if (main.Y == 0 && main.X == 0) //Přejít nahoru
                    {
                        t.Node = t.Root;
                        t.Stack.Clear();
                    }
                    else if (main.Y == 0 && main.X == 1) //Přejít na seznam
                    {
                        Console.Clear();
                        List(list, r, t, l);
                    }
                    else if (main.Y == 1 && main.X == 1) //Přidat
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
                    else if (main.Y == 2) //Přejít na nadřízeného
                    {
                        try
                        {
                            t.Node = t.Stack.Pop();
                            r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, main, t.Path);

                        }
                        catch
                        {
                            r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, main, t.Path);

                        }
                    }
                    else
                    {
                        t.Stack.Push(t.Node);
                        t.Node = t.Node.Subordinates[main.Y - 3];
                        main.FixCursorPosition(t.Node.Subordinates);
                    }

                    Console.Clear();

                }

                r.RenderMainInterface(t.Node, t.Root, t.Stack, t.List, main, t.Path);


            }

            static void List(Cursor list, Render r, Tree t, List l)
            {
                r.RenderList(t.List, list, t);

                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        if (list.X < 3)
                        {
                            list.X++;
                        }


                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        if (list.X > 0)
                        {
                            list.X--;

                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {

                        if (list.Y == 0 && list.X == 3) //Přejít na prohlížeč
                        {
                            Console.Clear();
                            break;
                        }
                        else if (list.Y == 0 && list.X == 2) //Uložit
                        {
                            l.SaveList(t.List, t);
                        }
                        else if (list.Y == 0 && list.X == 1) //Načíst list
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
                        else if (list.Y == 0 && list.X == 0) //Vytvořit list
                        {
                            l.CreateList(t);

                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        l.UnsavedListWarning(t.List, t);
                        Environment.Exit(0);
                    }
                    r.RenderList(t.List, list, t);

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
