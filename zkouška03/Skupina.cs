using zkouška03;

class Skupina
{
    private List<Zamestnanec> _zamestnanci;
    public string Popis
    {
        get
        {
            int pocetZen = _zamestnanci.FindAll(a => a.Pohlavi == Pohlavi.Zena).Count();
            int pocetMuzu = _zamestnanci.FindAll(a => a.Pohlavi == Pohlavi.Muz).Count();
            return $"Skupina {pocetMuzu} mužů a {pocetZen} žen";
        }
    }
    public double PrumernaMzda
    {
        get
        {
            return _zamestnanci.Sum(a => a.Mzda) / _zamestnanci.Count();
        }
    }
    public Skupina(Zamestnanec[] zamestnanci)
    {
        _zamestnanci = zamestnanci.ToList();
    }

    public void DoPrace()
    {
        Console.WriteLine($"Pracuje {_zamestnanci.Count()} zaměstnanců");
        foreach (var z in _zamestnanci)
        {
            Console.WriteLine(z.Jmeno + ": " + z.Pracuj());
        }
    }
}