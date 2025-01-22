namespace zkouska01
{
    internal class Ctverec : Obdelnik
    {
        public Ctverec(double stranaA) : base(stranaA, stranaA)
        {

        }

        public override string ToString()
        {
            return $"Čtverec o straně {StranaA}.";

        }
    }
}
