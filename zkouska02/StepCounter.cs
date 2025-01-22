namespace zkouska02
{
    internal class StepCounter(int step) : Counter
    {
        public int Step { get; private set; } = step;

        public override void Next()
        {
            Count += Step;
        }
    }
}
