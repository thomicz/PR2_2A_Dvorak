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

        public override bool IsMoveLegal(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            throw new NotImplementedException();
        }

        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            if (Math.Abs(fx - sx) == Math.Abs(fy - sy) && fx != sx)
            {
                ChessPiece destination = board[sx, sy];
                ChessPiece current = board[fx, fy];

                int dx = (sx - fx) > 0 ? 1 : -1;
                int dy = (sy - fy) > 0 ? 1 : -1;

                int x = fx + dx;
                int y = fy + dy;

                while (x != sx && y != sy)
                {
                    if (board[x, y] != null)
                    {
                        return false;
                    }

                    x += dx;
                    y += dy;
                }

                if (destination != null && destination.Color == current.Color)
                    return false;

                return true;
            }

            return false;
        }
    }
}
