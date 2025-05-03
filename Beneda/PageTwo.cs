namespace obchodni_sit;

public class PageTwo : IPage
{
    private List<IButton> _buttons = new();
    private Dictionary<int, Salesman> _salesmansId = new();
    private App _app;
    private int _index = 0;


    public PageTwo(Salesman root, App app)
    {
        while (root.Boss is not null)
        {
            root = root.Boss;
        }
        _app = app;
        MakeDictionary(root);
        if (_app.OpenFile is not null) OpenFile(_app.OpenFile);
        else OpenFile(_app.GetFileName());
    }


    public void OpenFile(string fileName)
    {
        _buttons.Clear();
        
        _buttons.Add(new PageButton(_app.Root ,_app));
        _buttons.Add(new FileNameButton(_app,this));

        string content = File.ReadAllText(_app.ListPath + fileName);
        int[] ids;
        if (content == "\n")
        {
            ids = new int[] {};
        }
        else
        {
            ids = content.Split(',').Select(int.Parse).ToArray();
        }
        foreach (var id in ids)
        {
            _buttons.Add(new SalesmanButton(_salesmansId[id],_app,this));
        }
        _app.OpenFile = fileName;
    }

    //private void MakeDictionary(Salesman root)
    //{
    //    SalesmansId[root.ID] = root;
    //    foreach (var subordinate in root.Subordinates)
    //    {
    //        MakeDictionary(subordinate);
    //    }
    //}

    private void MakeDictionary(Salesman root)
    {
        Stack<Salesman> stack = new();
        stack.Push(root);

        while (stack.Count > 0)
        {
            Salesman salesman = stack.Pop();
            _salesmansId[salesman.ID] = salesman;
            foreach (var subordinate in salesman.Subordinates)
            {
                stack.Push(subordinate);
            }
        }
    }




    public void Display()
    {
        _buttons[0].Print(0 == _index);
        Console.WriteLine();
        Console.Write("Cesta k souboru: ");
        _buttons[1].Print(1 == _index);
        Console.WriteLine();
        Console.WriteLine("-------------------");
        for (int i = 2; i < _buttons.Count; i++)
        {
            _buttons[i].Print(i == _index);
            Console.WriteLine();
        }
    }

    public void Up()
    {
        if (_index < _buttons.Count() - 1) _index++;
        
    }
    
    public void Down()
    {
        if (_index > 0) _index--;
    }


    public void PressSelect()
    {
        _buttons[_index].Press();
    }
    
    
    private class SalesmanButton : IButton
    {
        private Salesman _salesman;
        private App _app;
        private PageTwo _pageTwo;

        public SalesmanButton(Salesman salesman, App app, PageTwo pageTwo)
        {
            _salesman = salesman;
            _app = app;
            _pageTwo = pageTwo;
        }

        public void Press()
        {
            PageOne pageOne = new(_salesman, _app);
            _app.SelectPage = pageOne;
        }

        public void Print(bool select)
        {
            if (select) 
            {
                Console.Write("\u001b[43m\u001b[30m");
            }

            Console.Write($"{_salesman.Name} {_salesman.Surname}");

            if (select)
            {
                Console.Write("\u001b[0m");
            }
        }

    }

    private class FileNameButton : IButton
    {
        private App _app;
        private PageTwo _pageTwo;

        public FileNameButton(App app,PageTwo pageTwo)
        {
            _app = app;
            _pageTwo = pageTwo;
        }

        public void Press()
        {
            _pageTwo.OpenFile(_app.GetFileName());
        }

        public void Print(bool select)
        {
            if (select) 
            {
                Console.Write("\u001b[43m\u001b[30m");
            }

            Console.Write(_app.OpenFile);

            if (select)
            {
                Console.Write("\u001b[0m");
            }
        }
    }
    
    private class PageButton : IButton
    {
        private App _app;
        private Salesman _root;

        public PageButton(Salesman root, App app)
        {
            _app = app;
            _root = root;
        }

        public void Press()
        {
            _app.SelectPage = new PageOne(_root , _app);
        }

        public void Print(bool select)
        {
            if (select) 
            {
                Console.Write("\u001b[43m\u001b[30m");
            }
            else
            {
                Console.Write("\u001b[34m");
            }

            Console.Write("Zpet");
            
            Console.Write("\u001b[0m");
        }

    }
}