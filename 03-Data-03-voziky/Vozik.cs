namespace _03_Data_03_voziky
{
    internal class Vozik
    {
        public Vozik(int iD)
        {
            ID = iD;
        }

        public int? DobaProvozu { get;  set; } = 0;

        public int? DobaVraceni { get; private set; }
        public int ID { get;  set; }

        public void Pouzit(int cas, int aktualniCas)
        {
            DobaProvozu += cas;
            DobaVraceni = aktualniCas + cas;
        }

        public void Vratit()
        {
            DobaVraceni = null;
        }
    }
}
