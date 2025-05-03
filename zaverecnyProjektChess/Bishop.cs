namespace zaverecnyProjektChess
{
    internal class Bishop : ChessPiece
    {
        private Color _color;
        private int _x;
        private int _y;

        public Bishop(Color color, int x, int y)
        {
            _color = color;
            _x = x;
            _y = y;
        }
        public override int Value { get => 3; set => throw new NotImplementedException(); }
        public override ChessPieceName Name { get => ChessPieceName.Bishop; set => throw new NotImplementedException(); }
        public override Color Color => _color;
        public override int X => _x;
        public override int Y => _y;

        public override bool Move(int fx, int fy, int sx, int sy)
        {
            return true;
        }
    }
}
