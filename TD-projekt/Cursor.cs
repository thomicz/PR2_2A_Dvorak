using _03_Data_03_Obchodnici;

namespace TD_projekt
{
    internal class Cursor
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public void FixCursorPosition(List <Salesman> s)
        {
            if (s.Count == 0)
            {
                Y = 2;
            }
            else if (s.Count < Y)
            {
                Y = s.Count + 2;
            }
        }
    }
}
