using System.Collections;

namespace obchodni_sit;

public class PageOne : IPage
{
    
    
    private List<IButton> _buttons = new();
    private Salesman _selectSalesman;
    private int _index = 0;
    private App _app;
    
    

    public PageOne(Salesman salesman, App app)
    {
        _app = app;
        SetSalesman(salesman);
    }
    

    public void Display()
    {
        int i = 0;
        if (_selectSalesman.Boss is not null)
        {
            _buttons[i].Print(i == _index);
            Console.WriteLine();
            i++;
        }
        
        _buttons[i].Print(i == _index);
        i++;
        if (_app.OpenFile is not null)
        {
            Console.WriteLine();
            _buttons[i].Print(i == _index);
            i++;
        }
        Console.WriteLine();
        Console.WriteLine("-------------------");

        Console.WriteLine("OBCHODNIK: " + _selectSalesman.Name + " " + _selectSalesman.Surname);
        Console.WriteLine("PRIME PRODEJE: " + _selectSalesman.Sales + " $");
        Console.WriteLine("CELKOVY PRODEJ: " + _selectSalesman.AllSales  + " $");
        if (_selectSalesman.Boss is not null)
        {
            Console.WriteLine("NADRIZENY: " + _selectSalesman.Boss.Name  + " " + _selectSalesman.Boss.Surname);
        }

        Console.WriteLine("-------------------");
        Console.WriteLine("PODRIZENY: ");
        
        for (; i < _buttons.Count; i++)
        {
            Console.Write("    ");
            _buttons[i].Print(_index == i);
            Console.WriteLine();
        }
    }

    public void SetSalesman(Salesman salesman)
    {
        _buttons.Clear();
        if (salesman.Boss is not null) _buttons.Add(new GoUpButton(this));
        _buttons.Add(new PageTwoButton(salesman, _app));
        if(_app.OpenFile is not null) _buttons.Add(new AddButton(_app,this));

        foreach (var Subordinate in salesman.Subordinates)
        {
            _buttons.Add(MakeSalesmanButton(Subordinate));
        }
        
        _selectSalesman = salesman;
    }

    private SalesmanButton MakeSalesmanButton(Salesman salesman)
    {
        return new SalesmanButton(salesman, this);
    }
    
    public void PressSelect()
    {
        _buttons[_index].Press();
        _index = 0;
    }
    

    public void Up()
    {
        if (_index < _buttons.Count() - 1) _index++;
        
    }
    
    public void Down()
    {
        if (_index > 0) _index--;
    }




    private class GoUpButton : IButton
    {
        private PageOne _pageOne;

        public GoUpButton(PageOne pageOne)
        {
            _pageOne = pageOne;
        }

        public void Press()
        {
            _pageOne.SetSalesman(_pageOne._selectSalesman.Boss);
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

            Console.Write("Prejit Nahoru");
            
            Console.Write("\u001b[0m");
        }
    }
    
    private class PageTwoButton : IButton
    {
        private App _app;
        private Salesman _root;

        public PageTwoButton(Salesman root, App app)
        {
            _app = app;
            _root = root;
        }

        public void Press()
        {
            _app.SelectPage = new PageTwo(_root , _app);
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

            Console.Write("Prejit na seznam");
            
            Console.Write("\u001b[0m");
        }

    }
    
    private class AddButton : IButton
    {
        private App _app;
        private PageOne _pageOne;

        public AddButton(App app, PageOne pageOne)
        {
            _app = app;
            _pageOne = pageOne;
        }

        public void Press()
        {
            string content = File.ReadAllText(_app.ListPath + _app.OpenFile);
            int[] ids;
            if (content == "\n")
            {
                ids = new int[] {};
            }
            else
            {
                ids = content.Split(',').Select(int.Parse).ToArray();
            }

            List<int> list = new(ids);

            if (!(list.RemoveAll(x => x == _pageOne._selectSalesman.ID) > 0))
            {
                list.Add(_pageOne._selectSalesman.ID);
            }
            ids = list.ToArray();
            
            
            using (StreamWriter writer = new StreamWriter(_app.ListPath + _app.OpenFile))
            {
                writer.WriteLine(string.Join(",", ids));
            }

        }

        public void Print(bool select)
        {
            if (select) 
            {
                Console.Write("\u001b[43m\u001b[30m"); // Žluté pozadí (43) a černý text (30)
            }
            
            string content = File.ReadAllText(_app.ListPath + _app.OpenFile);
            int[] ids;
            if (content == "\n")
            {
                ids = new int[] {};
            }
            else
            {
                ids = content.Split(',').Select(int.Parse).ToArray();
            }
            if (Array.Exists(ids, x => x == _pageOne._selectSalesman.ID))
            {
                Console.Write("\u001b[31mSMAZET");
            }
            else
            {
                Console.Write("\u001b[32mPRIDAT");
            }
            
            Console.Write("\u001b[0m"); // Reset barev
        }
    }
    
    private class SalesmanButton : IButton
    {
        private Salesman _salesman;
        private PageOne _pageOne;

        public SalesmanButton(Salesman salesman, PageOne pageOne)
        {
            _salesman = salesman;
            _pageOne = pageOne;
        }

        public void Press()
        {
            _pageOne.SetSalesman(_salesman);
        }

        public void Print(bool select)
        {
            if (select) 
            {
                Console.Write("\u001b[43m\u001b[30m"); // Žluté pozadí (43) a černý text (30)
            }

            Console.Write($"{_salesman.Name} {_salesman.Surname}");

            if (select)
            {
                Console.Write("\u001b[0m"); // Reset barev
            }
        }
        
        

    }
}