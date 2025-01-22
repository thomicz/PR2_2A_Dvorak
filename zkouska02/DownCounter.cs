namespace zkouska02
{
    internal class DownCounter : StepCounter
    {
        public DownCounter(int step, int initValue) : base(step)
        {
            Count = initValue;
        }

        public override void Next() => Count -= Step;

        public bool IsFinished => Count <= 0;

    }
}
