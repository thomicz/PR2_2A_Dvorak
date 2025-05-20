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
        public bool WasAlreadyMoved = false;


        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {

            board[sx, sy] = board[fx, fy];
            board[fx, fy] = null;

            return true;

        }
        public override ChessPiece Clone()
        {
            Rook cloned = new Rook(this.Color, this.X, this.Y);
            return cloned;
        }

        public override bool IsMoveLegal(int fx, int fy, int sx, int sy, ChessPiece[,] board, bool ignoreCheck)
        {
            if (!ignoreCheck)
            {
                Board b = new Board();

                if (board[fx, fy] != null && board[fx, fy].Color == Color.White)
                {
                    if (b.IsWhiteKingInCheck(fx, fy, sx, sy, board))
                    {
                        return false;
                    }
                }
                else if (board[fx, fy] != null && board[fx, fy].Color == Color.Black)
                {
                    if (b.IsBlackKingInCheck(fx, fy, sx, sy, board))
                    {
                        return false;
                    }
                }
            }

            if (!((fx == sx && fy != sy) || (fy == sy && fx != sx)))
            {
                return false;
            }

            if (board[sx, sy] != null && board[sx, sy].Color == this.Color)
            {
                return false;
            }

            if (fx == sx)
            {
                int step = sy > fy ? 1 : -1;

                for (int y = fy + step; y != sy; y += step)
                {
                    if (board[fx, y] != null)
                    {
                        return false;
                    }
                }
            }
            else if (fy == sy)
            {
                int step = sx > fx ? 1 : -1;
                for (int x = fx + step; x != sx; x += step)
                {
                    if (board[x, fy] != null)
                    {
                        return false;
                    }
                }
            }

            return true;

        }
    }
}
