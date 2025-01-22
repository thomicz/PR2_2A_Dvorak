namespace _02_Dedicnost_07_IComparable
{
    internal class Bod : IComparable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Bod(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return string.Format("Bod [{0};{1}]", this.X, this.Y);
        }

        public double VzdalenostOdStredu()
        {
            return Math.Sqrt(this.X * this.X + this.Y * this.Y);
        }

        int IComparable.CompareTo(object? obj)
        {
            if (obj != null && obj is Bod tenDalsiBod)
            {
                return Math.Sign(this.VzdalenostOdStredu()-tenDalsiBod.VzdalenostOdStredu());

            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
