using _03_Data_03_Obchodnici;

namespace TD_projekt
{
    internal class List
    {
        public bool UnsavedListWarning(List<Salesman> list, Tree t)
        {
            Console.Clear();
            Console.WriteLine($"Chceš uložit svůj seznam? A/N");
            string input = Console.ReadLine();

            if (input.ToUpper() == "A")
            {
                SaveList(list, t);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddSalesmanToList(Salesman salesman, List<Salesman> list)
        {
            try
            {
                list.Add(salesman);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool RemoveSalesmanFromList(Salesman salesman, List<Salesman> list)
        {
            if (list.Contains(salesman))
            {
                list.Remove(salesman);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveList(List<Salesman> list, Tree t)
        {
            string filePath = t.Path;

            if (filePath != "")
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Salesman s = list[i];

                        writer.WriteLine($"{s.ID}");
                    }
                }
            }


            return true;
        }


        public Tuple<List<Salesman>, string> LoadList(Salesman root, Tree t)
        {
            Console.Write("Zadej název souboru: ");
            string path = Console.ReadLine();

            t.Path = path + ".txt";

            if (!File.Exists(t.Path))
            {
                return Tuple.Create(new List<Salesman>(), "");
            }

            List<Salesman> l = new List<Salesman>();

            string[] tmp = File.ReadAllLines(t.Path);

            for (int i = 0; i < tmp.Length; i++)
            {
                int n = int.Parse(tmp[i]);

                Salesman s = FindSalesmanById(root, n);

                if (s != null)
                {
                    l.Add(s);
                }
            }

            return Tuple.Create(l, path);
        }

        public bool CreateList(Tree t)
        {

            Console.WriteLine($"Zadej název souboru: ");
            string? input = Console.ReadLine();




            try
            {
                using (FileStream fs = File.Create($"{input}.txt"))
                {
                    fs.Close();
                }

                t.Path = input + ".txt";
                t.List.Clear();

                return true;

            }
            catch
            {
                return false;

            }
        }
        public Salesman FindSalesmanById(Salesman root, int id)
        {
            if (root == null)
            {
                return null;
            }

            Queue<Salesman> toBeVisited = new Queue<Salesman>();
            toBeVisited.Enqueue(root);

            while (toBeVisited.Count > 0)
            {
                Salesman node = toBeVisited.Dequeue();

                if (node.ID == id)
                {
                    return node;
                }

                foreach (Salesman child in node.Subordinates)
                {
                    toBeVisited.Enqueue(child);
                }
            }

            return null;
        }

    }




}

