using _03_Data_03_Obchodnici;

namespace TD_projekt
{
    internal class Render
    {
        public void RenderMainInterface(Salesman node, Salesman root, Stack<Salesman> s, List<Salesman> list, Cursor cursor, string path)
        {
            Console.SetCursorPosition(0, 0);

            if (cursor.X == 0 && cursor.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"Přejít nahoru");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Přejít nahoru");
                Console.ResetColor();
            }

            Console.Write($"    |   ");

            if (cursor.X == 1 && cursor.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Přejít na seznam");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Přejít na seznam");
                Console.ResetColor();
            }

            Console.WriteLine("-------------------------------------");
            Console.Write($"Obchodník: {node.Name} {node.Surname}");

            if (path != "")
            {
                if (cursor.Y == 1)
                {
                    if (cursor.X == 0)
                    {
                        cursor.X = 1;
                    }

                    if (list.Contains(node))
                    {
                        Console.SetCursorPosition(30, 2);
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Odebrat");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(31, 2);
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Přidat");
                        Console.ResetColor();
                    }
                }
                else
                {
                    if (list.Contains(node))
                    {
                        Console.SetCursorPosition(30, 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Odebrat");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(31, 2);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Přidat");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.WriteLine();
            }


            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Přímé prodeje: {node.Sales}$");
            Console.WriteLine($"Celkové prodeje sítě: {GetTotalSalesRecursive(node)}$");

            if (s.Count > 0)
            {
                if (cursor.Y == 2)
                {
                    Console.WriteLine("-------------------------------------");
                    Console.Write($"Nadřízený: ");
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{s.Peek().Name} {s.Peek().Surname}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Nadřízený: {s.Peek().Name} {s.Peek().Surname}");
                }
            }

            Console.WriteLine("-------------------------------------");

            if (node.Subordinates.Count > 0)
            {
                Console.Write($"Podřízení: ");

                for (int i = 0; i < node.Subordinates.Count; i++)
                {
                    if (cursor.Y == i + 3)
                    {
                        if (i == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"{node.Subordinates[i].Name} {node.Subordinates[i].Surname}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"           ");
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"{node.Subordinates[i].Name} {node.Subordinates[i].Surname}");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Console.WriteLine($"{node.Subordinates[i].Name} {node.Subordinates[i].Surname}");
                        }
                        else
                        {
                            Console.WriteLine($"           {node.Subordinates[i].Name} {node.Subordinates[i].Surname}");
                        }
                    }
                }

                Console.WriteLine("-------------------------------------");
            }
        }

        public void RenderList(List<Salesman> list, Cursor c, Tree t)
        {
            Console.SetCursorPosition(0, 0);
            if (c.X == 0 && c.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Založit");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Založit");
                Console.ResetColor();
            }

            Console.Write("    |    ");

            if (c.X == 1 && c.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Načíst");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Načíst");
                Console.ResetColor();
            }

            Console.Write("    |    ");

            if (c.X == 2 && c.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Uložit");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Uložit");
                Console.ResetColor();
            }

            Console.Write("    |    ");

            if (c.X == 3 && c.Y == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Přejít na prohlížeč");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Přejít na prohlížeč");
                Console.ResetColor();
            }

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Seznam: {t.Path}");
            Console.WriteLine("-----------------------------------------------------------------");


            Console.Write("Obsah: ");

            if (list.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------");

            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"{list[i].Name} {list[i].Surname}");
                }
                else
                {
                    Console.WriteLine($"       {list[i].Name} {list[i].Surname}");

                }
            }

            if (list.Count > 0)
            {
                Console.WriteLine("-----------------------------------------------------------------");
            }
        }

        public void RenderWarning(Cursor c)
        {
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("Chcete svůj seznam uložit?");
            Console.WriteLine("--------------------------");

            if (c.X == 0 && c.Y == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("ANO");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ANO");
                Console.ResetColor();
            }

            Console.Write("          |          ");

            if (c.X == 1 && c.Y == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write("NE");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("NE");
                Console.ResetColor();
            }
        }

        static int GetTotalSalesRecursive(Salesman node)
        {
            int sum = node.Sales;
            foreach (var sub in node.Subordinates)
                sum += GetTotalSalesRecursive(sub);
            return sum;
        }
    }
}

