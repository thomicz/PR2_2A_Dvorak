namespace zaverecnyProjektChess
{
    internal class Queen : ChessPiece
    {
        private Color _color;
        private int _x;
        private int _y;

        public Queen(Color color, int x, int y)
        {
            _color = color;
            _x = x;
            _y = y;
        }

        public override int Value { get => 9; set => throw new NotImplementedException(); }
        public override ChessPieceName Name { get => ChessPieceName.Queen; set => throw new NotImplementedException(); }
        public override Color Color => _color;
        public override int X => _x;
        public override int Y => _y;

        public override bool Move(int fx, int fy, int sx, int sy)
        {
            return true;
        }
    }
}
