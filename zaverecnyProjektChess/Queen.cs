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

        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            if (IsMoveLegal(fx, fy, sx, sy, board))
            {
                board[sx, sy] = board[fx, fy];
                board[fx, fy] = null;

                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool IsMoveLegal(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            ChessPiece destinationPiece = board[sx, sy];
            if (destinationPiece != null && destinationPiece.Color == this.Color)
                return false;

            if (fx == sx && fy != sy)
            {
                int step = sy > fy ? 1 : -1;

                for (int y = fy + step; y != sy; y += step)
                {
                    if (board[fx, y] != null)
                    {
                        return false;
                    }
                }
                return true;
            }

            if (fy == sy && fx != sx)
            {
                int step = sx > fx ? 1 : -1;
                for (int x = fx + step; x != sx; x += step)
                {
                    if (board[x, fy] != null)
                        return false;
                }
                return true;
            }

            if (Math.Abs(fx - sx) == Math.Abs(fy - sy) && fx != sx)
            {
                int stepX = sx > fx ? 1 : -1;
                int stepY = sy > fy ? 1 : -1;
                int x = fx + stepX;
                int y = fy + stepY;

                while (x != sx && y != sy)
                {
                    if (board[x, y] != null)
                    {
                        return false;
                    }

                    x += stepX;
                    y += stepY;
                }

                return true;
            }

            return false;
        }
    }
}
