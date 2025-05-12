namespace zaverecnyProjektChess
{
    internal class Rook : ChessPiece
    {
        private Color _color;
        private int _x;
        private int _y;

        public Rook(Color color, int x, int y)
        {
            _color = color;
            _x = x;
            _y = y;
        }

        public override int Value { get => 5; set => throw new NotImplementedException(); }
        public override ChessPieceName Name { get => ChessPieceName.Rook; set => throw new NotImplementedException(); }
        public override Color Color => _color;
        public override int X => _x;
        public override int Y => _y;

        public override bool IsMoveLegal(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            throw new NotImplementedException();
        }

        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            if (!((fx == sx && fy != sy) || (fy == sy && fx != sx)))
                return false;

            ChessPiece destinationPiece = board[sx, sy];

            if (destinationPiece != null && destinationPiece.Color == this.Color)
                return false;

            if (fx == sx)
            {
                int step = sy > fy ? 1 : -1;
                for (int y = fy + step; y != sy; y += step)
                {
                    if (board[fx, y] != null)
                        return false;
                }
            }
            else if (fy == sy)
            {
                int step = sx > fx ? 1 : -1;
                for (int x = fx + step; x != sx; x += step)
                {
                    if (board[x, fy] != null)
                        return false;
                }
            }

            return true;
        }

    }
}
