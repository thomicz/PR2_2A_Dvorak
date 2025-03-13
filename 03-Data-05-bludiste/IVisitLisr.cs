namespace _03_Data_05_bludiste
{
    internal interface IVisitLisr
    {
        int Count { get; }
        void Add(Coords place);
        Coords NextPlace();
    }
}
